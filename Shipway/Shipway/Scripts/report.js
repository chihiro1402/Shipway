DonutChar = {
    _data:null,
    _element: null,
    _props: null,
    _groupBy: null,
    _result: [],

    _init: function (data, element, props, groupBy) {
        this._data = data,
        this._element = element,
        this._props = props,
        this._groupBy = groupBy,
        this._result = [],
        this._draw();
    },

    _check: function(label){
        if(!exits(that.result, "label",label)){
            this._result.push({
                "label":label,
                "value":0.00
            })
        }
    },

    _draw: function () {
        var that=this;
            countItem,
            sum;
            _.each(that._data, function (item) {
                if (exist(that._result, "label", item[that._groupBy])) {
                    return;
                }

                countItem = count(that._data, that._groupBy, item[that._groupBy]);

                that._result.push(
                        {
                            "label": item[that._groupBy],
                            "value": countItem
                        }
                    );
            });
            if (that._result.length) {
                sum = that._data.length;
                _.each(that._result, function (item) {
                    item.value = Math.round(((item.value * 100 / sum) * 100) / 100);
                });

                _.each(that._props.labels, function (item) {
                    that._check(item);
                })

                that._result = _.sortBy(that._result, "label");

                Morris.Donut({
                    element: that._elment,
                    data: that._result,
                    color: that._props.colors,
                    formatter: function (value, data) { return value + '%'; }
                });
            }
    }
}

ExhibitionDaily = {

}

function count(array, groupby, value) {
    var result = _.filter(array, function (item) {
        return item[groupby].toLowerCase() == value.toLowerCase();
    }).length;

    return result;
}