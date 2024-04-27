
class ActionSection {
    constructor({ tableId, bulkCheckboxId, rowCheckboxClassName, actionSectionId, actionSectionFormId, stdRowSpanId, totalRowSpanId }) {
        this.table = $(`#${tableId}`);
        this.tableRows = this.table.find("tbody tr")
        this.totalRows = 0;
        this.selectedRows = 0;

        this.bulkCheckbox = this.table.find(`thead #${bulkCheckboxId}`); // Checkbox which exists on the head
        this.checkboxes = this.table.find(`tbody input.${rowCheckboxClassName}`); // Checkboxes which exist on row
        this.wholeCheckboxes = null;

        this.actionSection = $(`#${actionSectionId}`);
        this.actionSectionFormId = actionSectionFormId;

        this.stdRowSpan = $(`#${stdRowSpanId}`);
        this.totalRowSpan = $(`#${totalRowSpanId}`);

    }

    init() {        
        this.wholeCheckboxes = this.mergeCheckboxes(this.bulkCheckbox, this.checkboxes);

        this.addCheckedEventListener(this.evaluateBulkCheckbox, this.bulkCheckbox, "change")
        this.addCheckedEventListener(this.evaluateActionSection, this.wholeCheckboxes, "change")
        this.addCheckedEventListener(this.updateSelectedRowsSpan, this.wholeCheckboxes, "change")
        this.addCheckedEventListener(this.selectOrUnselectBulkCheckbox, this.checkboxes, "change")
        this.addCheckedEventListener(this.updateCheckboxFormAttr, this.wholeCheckboxes, "change")

        this.totalRows = this.calculateTotalRows(this.tableRows);
        this.setTotalRowsSpan(this.totalRowSpan, this.totalRows);
    }
        
    addCheckedEventListener(eventHandler, elements, event) {
        elements.each((index, element) => {
            $(element).on(event, eventHandler.bind(this));
        })
    }

    evaluateActionSection(event) {
        let selectedCheckboxes = this.getSelectedCheckboxes(this.wholeCheckboxes);
        if (selectedCheckboxes.length > 0) {
            this.showActionSection(this.actionSection);
        }
        else {
            this.hideActionSection(this.actionSection);
        }
    }

    evaluateBulkCheckbox(event) {
        if (this.bulkCheckbox.is(":checked")) {
            this.selectCheckboxes(this.wholeCheckboxes);
        }
        else {
            this.unselectCheckboxes(this.wholeCheckboxes)
        }
    }

    selectOrUnselectBulkCheckbox(event) {
        let checkboxesCount = this.checkboxes.length;
        let unselectedCheckboxes = this.getUnselectedCheckboxes(this.checkboxes);
        let unselectedCheckboxesCount = unselectedCheckboxes.length;

        let selectedChecboxes = this.getSelectedCheckboxes(this.checkboxes);
        let selectedCheckboxesCount = selectedChecboxes.length;


        if (this.bulkCheckbox.is(":checked") && checkboxesCount > unselectedCheckboxesCount) {
            this.unselectCheckboxes(this.bulkCheckbox)
        }
        else if (this.bulkCheckbox.is(":not(:checked)") && checkboxesCount == selectedCheckboxesCount) {
            this.selectCheckboxes(this.bulkCheckbox)
        }

    }

    updateSelectedRowsSpan(event) {
        let selectedRows = this.getSelectedCheckboxes(this.checkboxes);
        let selectedRowsCount = selectedRows.length

        this.setSelectedRowsSpan(this.stdRowSpan, selectedRowsCount)
    }

    updateCheckboxFormAttr(event) {
        let selectedCheckboxes = this.getSelectedCheckboxes(this.checkboxes);
        let unselectedCheckboxes = this.getUnselectedCheckboxes(this.checkboxes);

        selectedCheckboxes.each((index, checkbox) => {
            $(checkbox).attr("form", this.actionSectionFormId);
        })

        unselectedCheckboxes.each((index, checkbox) => {
            $(checkbox).removeAttr("form");
        })
    }
  

    getCorrespondingRow(checkboxes) {
        return checkboxes.parents("tr");
    }

    getSelectedCheckboxes(checkboxes) {
        return checkboxes.filter(':checked')
    }

    getUnselectedCheckboxes(checkboxes) {
        return checkboxes.filter(':not(:checked)')
    }


    showActionSection(actionSection) {
        actionSection.show("slow");
    }

    hideActionSection(actionSection) {
        actionSection.hide("slow");
    }


    selectCheckboxes(checkboxes) {
        checkboxes.each((index, checkbox) => {
            $(checkbox).prop('checked', true);
        })
    }

    unselectCheckboxes(checkboxes) {
        checkboxes.each((index, checkbox) => {
            $(checkbox).prop('checked', false);
        })
    }


    mergeCheckboxes(firstCheckboxes, secondCheckboxes) {
        return firstCheckboxes.add(secondCheckboxes)
    }

    setTotalRowsSpan(totalRowsSpan, rowsCount) {
        totalRowsSpan.html(rowsCount);
    }

    setSelectedRowsSpan(stdRowsSpan, selectedRowsCount) {
        stdRowsSpan.html(selectedRowsCount)
    }

    calculateTotalRows(rows) {
        return rows.length
    }
}

