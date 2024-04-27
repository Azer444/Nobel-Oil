class Sorting {
    constructor({ tableId, sortInputName, sortInputValue, submitRoute, submitMethod }) {
        this.tableId = tableId;
        this.sortInputName = sortInputName;
        this.sortInputValue = sortInputValue;
        this.submitRoute = submitRoute;
        this.submitMethod = submitMethod;
    }
    init() {
        this.table = this.getTableById(this.tableId);
        this.columns = this.getHeadersByAttr(this.table, "data-column");
        this.evaluateSortInputValueOnLoad();
        this.addCheckedEventListener(this.handleHeaderClick, this.columns, "click");
    }
    addCheckedEventListener(eventHandler, elements, event) {
        elements.each((index, element) => {
            $(element).on(event, eventHandler.bind(this));
        })
    }
    handleHeaderClick(event) {
        let header = $(event.target)
        let column = header.data("column");
        let submitValue = this.getSubmitValue(this.sortInputValue, column)
        this.submitForm(this.submitRoute, this.submitMethod, this.sortInputName, submitValue)
    }
    evaluateSortInputValueOnLoad() {
        let values = this.getSplittedSortValue(this.sortInputValue);
        let headers = this.getHeadersByColumn(this.table, values.column)
        let icon = this.getOrderTypeIcon(values.order_type);
        this.addOrderTypeIcon(headers, icon);
    }
    getSubmitValue(sortedInputValue, column) {
        let values = this.getSplittedSortValue(sortedInputValue)
        if (values.column == column) {
            if (values.order_type == "asc") {
                return `${column}_desc`
            }
        }
        return `${column}_asc`
    }
    addOrderTypeIcon(header, icon) {
        header.children("span").after(icon)
    }
    getOrderTypeIcon(orderType) {
        if (orderType == "asc") {
            return '<i class="fas fa-sort-up" style="pointer-events: none;"></i>'
        }
        else if (orderType == "desc") {
            return '<i class="fas fa-sort-down" style="pointer-events: none;"></i>'
        }
        return ""
    }
    getHeadersByColumn(table, column) {
        return table.find(`thead tr th[data-column="${column}"]`)
    }
    getHeadersByAttr(table, attributeName) {
        return table.find(`thead tr th[${attributeName}]`)
    }
    getSplittedSortValue(sortInputValue) {
        let values = sortInputValue.split("_")
        return { "column": values[0], "order_type": values[1] }
    }
    getColumn(header) {
        return header.data("column")
    }
    getTableById(tableId) {
        return $(`#${tableId}`)
    }
    submitForm(route, method, name, value) {
        $(`<form action="${route}" method="${method}" class="d-none"/>`)
            .append($(`<input type="hidden" name="${name}">`).val(value))
            .appendTo($(document.body)) //it has to be added somewhere into the <body>
            .submit();
    }

}