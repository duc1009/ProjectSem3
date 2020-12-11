var _pageSizeDefault = 10;
var listDataSelected = [];

var tvTablePagination = function (config) {

    var _config = {
        tableContainer: '.tbl-hd',
        tableId: '#createPagination',
        data: { Items: [], TotalItems: 0},
        templateTr: "",
        templateEmpty: "",
        callBackSelectPage: function (pageSelected) {
            alert("Page:" + pageSelected+". Vui lòng khởi tạo sự kiện paging.")
        },
        pageSizeDefault: _pageSizeDefault
    }
    
    if (config != undefined) {
        _config = $.extend(_config, config);
    }

    var templateTr = function () {
        
        if (_config.templateTr != undefined && _config.templateTr.length != 0) {
            return _config.templateTr;
        } else {
            var template = `<tr data-id="{{value0}}">`;
            if (_config.data.Items != [] && _config.data.Items != undefined) {
                let keys = Object.keys(_config.data.Items[0]);
                for (var i = 1; i < keys.length; i++) {
                    template += `<td class="text-center ">
							{{value`+ i + `}}
                        </td>`;
                }
            }

            template += `</tr>`;
            return template;
        }
    };

    var templateEmpty = function () {
        if (_config.templateEmpty != undefined && _config.templateEmpty.length != 0) {
            return _config.templateEmpty;
        } else {
            var numCol = getInstance().selector.find("th").length;
            var numColMobile = numCol - getInstance().selector.find("th.mobile-hide").length;
            var template = `<tr style="text-align : center;" class="mobile-hide"><td colspan="` + numCol + `">Không có dữ liệu được tìm thấy</td></tr>
                            <tr style="text-align : center;" class="mobile-show"><td colspan="`+ numColMobile + `">Không có dữ liệu được tìm thấy</td></tr>`;
            return template;
        }
    };

    var createTr = function (dataRow) {
        // Lấy ds property của object
        let keys = Object.keys(dataRow);
        var mapObj = {};
        // Tạo mapping giữa key trong template với dữ liệu object datarow truyền vào
        for (var i = 0; i < keys.length; i++) {
            mapObj["{{value" + i + "}}"] = dataRow[keys[i]];
        }
        // Thực hiện thay thế dữ liệu datarow vào template theo obj mapping vừa tạo
        var re = new RegExp(Object.keys(mapObj).join("|"), "gi");
        let trRow = templateTr().replace(re, function (matched) {
            return mapObj[matched];
        });

        return trRow;
    };

    var addToTable = function (dataRow) {
        if (getInstance().tr().length < _config.pageSizeDefault) {
            getInstance().selector.find('tbody').append(createTr(dataRow));
        }
    };

    var addToData = function (dataRow) {
        //chưa có trong danh sách mới thêm
        if (!listDataSelected.some(x => x.Id == dataRow.Id)) {
            listDataSelected.push(dataRow);

            return true;
        }

        return false;
    };

    var pagination = $(_config.tableContainer).find('.pagination-container').paginationv2({
        currentPage: 1,
        totalItems: _config.data.TotalItems,
        pageSize: _config.pageSizeDefault,
        selectPageCallback: function (pageNumber) {
            callBackSelectPage(pageNumber);
        }
    });

    var createPagination = function (currentPage) {
        var totalItems = _config.data.TotalItems;
        getInstance().container.find('.pagination-container').paginationv2({
            currentPage: currentPage ? currentPage : 1,
            totalItems: totalItems,
            pageSize: _config.pageSizeDefault,
            selectPageCallback: function (pageSelected) {
                callBackSelectPage(pageSelected);
            }
        });
    }

    var mathPagination = function (pageSelected) {
        let fromRecord = (pageSelected - 1) * _config.pageSizeDefault;
        let totalRecord = fromRecord + _config.pageSizeDefault;

        return {
            pageSelected,
            fromRecord,
            totalRecord
        }
    }

    var tr = function (condition) {
        return getInstance().selector.find(`tbody tr${condition ? condition : ''}`);
    };

    var selectAllOnePage = function (isChecked) {
        getInstance().selector.find('.select-all').prop('checked', isChecked);
        var trs = tr();
        if (trs) {
            trs.find('.select-user').prop('checked', isChecked);

            trs.find('.select-user').each(function (i, el) {
                var user = listDataSelected.find(x => x.id == $(el).closest('tr').attr('data-id'));
                console.log(`edit user`, user.name);
                user.isSelected = isChecked;
            });
        }
    }

    var selectUser = function (isChecked, userId) {
        var user = listDataSelected.find((user) => user.id == userId);
        if (user) {
            user.isSelected = isChecked;
        }

        //bỏ dấu check của checkbox select all
        if (isChecked == false) {
            getInstance().selector.find('.select-all').prop('checked', isChecked);
        }
    }

    var callBackSelectPage = function (pageSelected) {

        _config.callBackSelectPage(pageSelected);
        createPagination(pageSelected);
    }

    var getCurrentPage = function () {
        return getInstance().container.find('.pagination-container').attr('data-currentPage') > 0 ? $(_config.tableContainer).find('.pagination-container').attr('data-currentPage') : 1;
    };

    var render = function () {
        var paginationInfo = mathPagination(getCurrentPage());

        getInstance().tbody.html('');
        if (_config.data != undefined && _config.data.Items.length > 0) {
            _config.data.Items.forEach((dataRow) => {
                addToTable(dataRow);
            })
        } else {
            getInstance().tbody.html(templateEmpty());
        }

        createPagination(paginationInfo.pageSelected);
    }

    var loadData = function () {
        calendarApi.getUserInEvent(_eventId, null, null, function (res) {
            if (res) {
                res.Items.forEach(item => {
                    //tableUserSelected.addToData(user);
                    getInstance().addToTable(item);
                });

                getInstance().render();
            }
        });
    }

    var init = function (config) {
        _config = $.extend(_config, config);
        getInstance().render();
        return getInstance();
    }

    var getInstance = function () {
        return {
            container: $(_config.tableContainer),
            selector: $(_config.tableId),
            tbody: $(_config.tableId).find('tbody'),
            tr: function (condition) {
                return $(_config.tableId).find(`tbody tr${condition ? condition : ''}`);
            },
            templateEmpty: templateEmpty,
            pagination: pagination,
            createPagination: createPagination,
            isSelectAll: function () {
                return $tbUsersThenFilter.attr('data-selectAllUser') == 'true' ? true : false;
            },
            init: init,
            addToTable: addToTable,
            addToData: addToData,
            clearHtml: function () {
                this.tbody().html('');
            },
            render: render,
            selectAll: function (ip) {
                listDataSelected.forEach((user) => {
                    user.isSelected = ip.checked;
                });

                var trs = this.tr();
                if (trs) {
                    trs.find('.select-user').prop('checked', ip.checked);
                }
            },
            selectAllOnePage: selectAllOnePage,
            selectUser: selectUser,
            removeUsers: function (ip) {
                //chỉ giữ lại user k bị chọn
                listDataSelected = listDataSelected.filter((user) => {
                    if (user.isSelected) {
                        //var tr = this.tr('[data-id="' + user.id + '"]');
                        //if (tr) {
                        //    tr.remove();
                        //}

                        return false;
                    }

                    return true;
                });

                this.render();
            },
            searchData: function (searchString) {
                searchString = calendarModuleJS.convertTV(searchString);
                //tìm tất cả các kết quả phù hợp với seachString
                listDataSelected.forEach((user) => {
                    //reset lại giá trị đã
                    user.isSearchResult = false;

                    if (calendarModuleJS.convertTV(user.name).indexOf(searchString) >= 0) {
                        user.isSearchResult = true;
                    }
                });

                render();
            },
            loadData: loadData
        }
    }

    return { 
        container: $(_config.tableContainer),
        selector: $(_config.tableId),
        tbody: $(_config.tableId).find('tbody'),
        tr: function (condition) {
            return $(_config.tableId).find(`tbody tr${condition ? condition : ''}`);
        },
        templateEmpty: templateEmpty,
        pagination: pagination,
        createPagination: createPagination,
        isSelectAll: function () {
            return $tbUsersThenFilter.attr('data-selectAllUser') == 'true' ? true : false;
        },
        init: init,
        addToTable: addToTable,
        addToData: addToData,
        clearHtml: function () {
            this.tbody().html('');
        },
        render: render,
        selectAll: function (ip) {
            listDataSelected.forEach((user) => {
                user.isSelected = ip.checked;
            });

            var trs = this.tr();
            if (trs) {
                trs.find('.select-user').prop('checked', ip.checked);
            }
        },
        selectAllOnePage: selectAllOnePage,
        selectUser: selectUser,
        removeUsers: function (ip) {
            //chỉ giữ lại user k bị chọn
            listDataSelected = listDataSelected.filter((user) => {
                if (user.isSelected) {
                    //var tr = this.tr('[data-id="' + user.id + '"]');
                    //if (tr) {
                    //    tr.remove();
                    //}

                    return false;
                }

                return true;
            });

            this.render();
        },
        searchData: function (searchString) {
            searchString = calendarModuleJS.convertTV(searchString);
            //tìm tất cả các kết quả phù hợp với seachString
            listDataSelected.forEach((user) => {
                //reset lại giá trị đã
                user.isSearchResult = false;

                if (calendarModuleJS.convertTV(user.name).indexOf(searchString) >= 0) {
                    user.isSearchResult = true;
                }
            });

            render();
        },
        loadData: loadData,
        getInstance: getInstance
    }
};