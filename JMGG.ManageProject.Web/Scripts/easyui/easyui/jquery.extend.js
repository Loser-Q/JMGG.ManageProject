$.json2Table = (function ($) {
    var json2Table = function (ops) {
        var defaults = {
            columns: [],
            rows: []
        };
        var options = $.extend(defaults, ops);
        if (options.columns.length == 0 && options.rows.length == 0) return "";
        var thead = "<thead><tr>";
        var cols = new Array();
        if (options.columns.length == 0) {
            for (var key in options.rows[0]) {
                thead += "<th>" + key + "</th>"
                cols[cols.length] = key;
            }
        }
        else {
            for (var rIndex = 0; rIndex < options.columns.length; rIndex++) {
                var column = options.columns[rIndex]
                for (var key in column) {
                    console.log(key);
                    thead += "<th>" + column[key] + "</th>"
                    cols[cols.length] = key;
                }
            }
        }
        thead += "</tr></thead>";
        var tbody = "<tbody>"
        for (var rIndex = 0; rIndex < options.rows.length; rIndex++) {
            tbody += "<tr>";
            for (var cIndex = 0; cIndex < cols.length; cIndex++) {
                tbody += "<td>" + options.rows[rIndex][cols[cIndex]] + "</td>";
            }
            tbody += "</tr>";
        }
        tbody += "</tbody>"
        return "<table>" + thead + tbody + "</table>";
    }
    return json2Table;
})(jQuery);
