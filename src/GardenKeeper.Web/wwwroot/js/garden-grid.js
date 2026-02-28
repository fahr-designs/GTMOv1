/**
 * GardenKeeper — Garden Grid Interactive Planner
 * Uses CSS Grid + jQuery for garden bed cell placement.
 */

(function ($) {
    'use strict';

    // ── State ────────────────────────────────────────────────────────────────
    let selectedPlant = null;   // { id, name, type, spacingInches }
    let currentMode = 'freeform';
    const CELL_SIZE = 48;       // matches CSS .garden-cell width/height

    // Plant type → background color map
    const PLANT_COLORS = {
        'Vegetable':   '#2e7d32',
        'Fruit':       '#e65100',
        'Flower':      '#ad1457',
        'Herb':        '#00796b',
        'NativePlant': '#4527a0',
        'Other':       '#455a64'
    };

    // ── Init ─────────────────────────────────────────────────────────────────
    $(function () {
        const $grid = $('#garden-grid');
        if (!$grid.length) return;

        const bedId   = parseInt($grid.data('bed-id'));
        const width   = parseInt($grid.data('width'));
        const length  = parseInt($grid.data('length'));
        const placements = JSON.parse($grid.attr('data-placements') || '[]');

        buildGrid($grid, width, length, bedId);
        renderPlacements(placements);
        initPlantSearch();
    });

    // ── Build the CSS Grid ────────────────────────────────────────────────────
    function buildGrid($container, width, length, bedId) {
        $container.css({
            'grid-template-columns': `repeat(${width}, ${CELL_SIZE}px)`,
            'grid-template-rows':    `repeat(${length}, ${CELL_SIZE}px)`
        });

        for (let y = 0; y < length; y++) {
            for (let x = 0; x < width; x++) {
                const $cell = $('<div>')
                    .addClass('garden-cell')
                    .attr({
                        'data-x': x,
                        'data-y': y,
                        'data-bed-id': bedId
                    })
                    .attr('title', `(${x + 1}, ${y + 1})`);

                $cell.on('click', handleCellClick);
                $cell.on('contextmenu', handleCellRightClick);
                $container.append($cell);
            }
        }
    }

    // ── Render existing placements ────────────────────────────────────────────
    function renderPlacements(placements) {
        placements.forEach(function (p) {
            const $cell = getCell(p.gridX, p.gridY);
            if ($cell.length) {
                markCell($cell, p.id, p.name, p.type);
            }
        });
    }

    // ── Get cell by grid coordinates ─────────────────────────────────────────
    function getCell(x, y) {
        return $(`.garden-cell[data-x="${x}"][data-y="${y}"]`);
    }

    // ── Mark a cell as occupied ───────────────────────────────────────────────
    function markCell($cell, placementId, plantName, plantType) {
        const color = PLANT_COLORS[plantType] || '#455a64';
        $cell
            .addClass('has-plant')
            .css('background', color)
            .attr('data-placement-id', placementId)
            .attr('data-plant-name', plantName)
            .attr('title', `${plantName}\nRight-click to remove`)
            .text(abbreviate(plantName));
    }

    // ── Clear a cell ──────────────────────────────────────────────────────────
    function clearCell($cell) {
        $cell
            .removeClass('has-plant highlighted')
            .css('background', '')
            .removeAttr('data-placement-id data-plant-name')
            .attr('title', `(${parseInt($cell.data('x')) + 1}, ${parseInt($cell.data('y')) + 1})`)
            .text('');
    }

    // ── Click: place plant ────────────────────────────────────────────────────
    function handleCellClick() {
        const $cell = $(this);
        if (currentMode !== 'freeform') return;
        if (!selectedPlant) {
            showInfo('Select a plant from the palette first.');
            return;
        }
        if ($cell.hasClass('has-plant')) {
            showInfo('Cell already occupied. Right-click to remove.');
            return;
        }

        const bedId = parseInt($cell.data('bed-id'));
        const x     = parseInt($cell.data('x'));
        const y     = parseInt($cell.data('y'));

        $.ajax({
            url: '/Beds/AddPlacement',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ bedId: bedId, plantId: selectedPlant.id, gridX: x, gridY: y }),
            headers: { 'RequestVerificationToken': getAntiForgeryToken() },
            success: function () {
                markCell($cell, null, selectedPlant.name, selectedPlant.type);
                highlightAdjacentCells($cell, selectedPlant.spacingInches);
            },
            error: function (xhr) {
                showInfo('Could not place plant: ' + (xhr.responseText || 'unknown error'));
            }
        });
    }

    // ── Right-click: remove plant ─────────────────────────────────────────────
    function handleCellRightClick(e) {
        e.preventDefault();
        const $cell = $(this);
        if (!$cell.hasClass('has-plant')) return;

        const placementId = parseInt($cell.attr('data-placement-id'));
        if (!placementId) {
            clearCell($cell);
            return;
        }

        $.ajax({
            url: '/Beds/RemovePlacement',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(placementId),
            headers: { 'RequestVerificationToken': getAntiForgeryToken() },
            success: function () {
                clearCell($cell);
                $('.garden-cell.highlighted').removeClass('highlighted');
            },
            error: function () {
                showInfo('Could not remove plant. Try again.');
            }
        });
    }

    // ── Highlight adjacent cells based on spacing ─────────────────────────────
    function highlightAdjacentCells($cell, spacingInches) {
        const radiusCells = Math.ceil(spacingInches / 12);
        const cx = parseInt($cell.data('x'));
        const cy = parseInt($cell.data('y'));

        for (let dy = -radiusCells; dy <= radiusCells; dy++) {
            for (let dx = -radiusCells; dx <= radiusCells; dx++) {
                if (dx === 0 && dy === 0) continue;
                const $adj = getCell(cx + dx, cy + dy);
                if ($adj.length && !$adj.hasClass('has-plant')) {
                    $adj.addClass('highlighted');
                    setTimeout(() => $adj.removeClass('highlighted'), 2000);
                }
            }
        }
    }

    // ── Guided layout ─────────────────────────────────────────────────────────
    window.applyGuidedLayout = function () {
        const bedId = parseInt($('#garden-grid').data('bed-id'));
        const goal  = $('#guided-goal').val();

        $.ajax({
            url: '/Beds/GetGuidedLayout',
            method: 'GET',
            data: { bedId: bedId, goal: goal },
            success: function (suggestions) {
                if (!suggestions || !suggestions.length) {
                    showInfo('No suggestions available for this goal.');
                    return;
                }
                suggestions.forEach(function (s) {
                    const $cell = getCell(s.gridX, s.gridY);
                    if ($cell.length && !$cell.hasClass('has-plant')) {
                        $.ajax({
                            url: '/Beds/AddPlacement',
                            method: 'POST',
                            contentType: 'application/json',
                            data: JSON.stringify({ bedId: bedId, plantId: s.plantId, gridX: s.gridX, gridY: s.gridY }),
                            headers: { 'RequestVerificationToken': getAntiForgeryToken() },
                            success: function () {
                                markCell($cell, null, s.plantName, 'NativePlant');
                            }
                        });
                    }
                });
            }
        });
    };

    // ── Mode toggle ───────────────────────────────────────────────────────────
    window.setMode = function (mode) {
        currentMode = mode;
        if (mode === 'guided') {
            $('#btn-guided').addClass('btn-success').removeClass('btn-outline-success');
            $('#btn-freeform').removeClass('btn-success').addClass('btn-outline-success');
            $('#guided-options').removeClass('d-none');
        } else {
            $('#btn-freeform').addClass('btn-success').removeClass('btn-outline-success');
            $('#btn-guided').removeClass('btn-success').addClass('btn-outline-success');
            $('#guided-options').addClass('d-none');
        }
    };

    // ── Select plant from palette ─────────────────────────────────────────────
    window.selectPlant = function (el) {
        const $el = $(el);
        $('.plant-item').removeClass('selected');
        $el.addClass('selected');

        selectedPlant = {
            id:            parseInt($el.data('plant-id')),
            name:          $el.data('plant-name'),
            type:          $el.data('plant-type'),
            spacingInches: parseFloat($el.data('spacing'))
        };

        $('#selected-plant-info').html(
            `<strong>${selectedPlant.name}</strong><br>` +
            `Spacing: ${selectedPlant.spacingInches}". ` +
            `Click a cell to place.`
        );
    };

    // ── Plant palette search ──────────────────────────────────────────────────
    function initPlantSearch() {
        $('#plant-search').on('input', function () {
            const q = $(this).val().toLowerCase();
            $('.plant-item').each(function () {
                const name = $(this).data('plant-name').toLowerCase();
                $(this).toggle(name.includes(q));
            });
        });
    }

    // ── Helpers ───────────────────────────────────────────────────────────────
    function abbreviate(name) {
        const words = name.split(' ');
        if (words.length === 1) return name.substring(0, 4);
        return words.slice(0, 2).map(w => w.substring(0, 3)).join(' ');
    }

    function getAntiForgeryToken() {
        return $('input[name="__RequestVerificationToken"]').val() ||
               $('meta[name="__RequestVerificationToken"]').attr('content') || '';
    }

    function showInfo(msg) {
        $('#selected-plant-info').text(msg);
    }

}(jQuery));
