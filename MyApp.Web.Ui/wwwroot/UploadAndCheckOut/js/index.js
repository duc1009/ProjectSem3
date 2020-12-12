var FDMModule = {
    api: {
        _getDanhMucKhachHang: function (requestObject) {
            var queryString = $.param(requestObject);
            return "api/FDM/GetDanhMucKhachHang?" + queryString;
        },
        _getDanhSachTuyenKhachHang: function (requestObject) {
            var queryString = $.param(requestObject);
            return "api/FDM/GetDanhMucNhomKhachHang?" + queryString;
        },
        _getChiTietHoaDon: function (requestObject) {
            var queryString = $.param(requestObject);
            return "api/FDM/GetChiTietHoaDon?" + queryString;
        },
        _addHoaDon: function () {
            return "api/FDM/AddHoaDon"
        },
        _editHoaDon: function () {
            return "api/FDM/EditHoaDon"
        },
        _getDanhSachHoaDon: function (requestObject) {
            var queryString = $.param(requestObject);
            return "api/FDM/GetDanhSachHoaDon?" + queryString;
        },
        _getMaHoaDonMoi: function () {
            return "api/FDM/GetMaHoaDonMoi"
        },
        _getDanhMucHangHoa: function (requestObject) {
            var queryString = $.param(requestObject);
            return "api/FDM/GetDanhMucHangHoa?" + queryString;
        },
        _deleteHoadon: function (requestObject) {
            var queryString = $.param(requestObject);
            return "api/FDM/DeleteHoaDon?" + queryString;
        },
    }
}
// lấy token từ cookies
var token = global.getCookie("auth-jwt");

$(function () {
    $.noConflict();
    $("#dpNgayLapFilter").datepicker(
        { dateFormat: 'dd/mm/yy' }
    ).on("input change", function (e) {
        var soHoaDon = $('#soHDFilter').val();
        var maKh = $('#maKHFilter').val();
        // định dạng dd/MM/yyyy
        var ngay_lap = $("#dpNgayLapFilter").val().replace(/[\/]/g, '_');
        // đổi thành yyyy_MM_dd gửi lên sv
        if (ngay_lap != "") {
            var paths = ngay_lap.split('_');
            ngay_lap = paths[2] + '_' + paths[1] + '_' + paths[0];
        }
        GetDanhSachHoaDon(1, 10, soHoaDon, maKh, ngay_lap);
    });

    $("#dpNgayLap").datepicker(
        { dateFormat: 'dd/mm/yy' }
    );
    $("#dpNgayLapEdit").datepicker(
        { dateFormat: 'dd/mm/yy' }
    );
    //$('#editHoaDonModal').on('shown.bs.modal', function (e) {
    //    $(".error-message").remove()
    //})
    //$('#addHoaDonModal').on('shown.bs.modal', function (e) {
    //    $(".error-message").remove()
    //})
    GetDanhSachHoaDon(1, 10);
    initDropdownKhachHang();

    // Add mã khách hàng tbl add
    $('#maKhachHang').on('select2:select', function (e) {
      
        let keyWord = $('#maKhachHang').val();
        if (keyWord!=0) {
            var getMaKhachHang = FDMModule.api._getDanhMucKhachHang({ PageNumber: 1, PageSize: 1, maNhomKhachHang: "", keyWord: keyWord });

            global.callApi(getMaKhachHang, "GET", null, "", function (data) {
                $('#tenKhachHang').val(data.listDanhMucKhachHang[0].ten_kh + "");
            });
        }
      

    });

    // Add mã khách hàng tbl edit
    $('#maKhachHangEdit').on('select2:select', function (e) {
        let keyWord = $('#maKhachHangEdit').val();
        ChangeCustomerName(keyWord);

    });

    // add thêm chi tiết  add hóa đơn
    $("#addRow, #addRowBottom").each(function () {
        $(this).on("click", function () {
            $("#tblAddHoaDon tbody").append(`<tr>
                                                      <td >
                                                           <form action="/action_page.php">
                                                          
                                                            <input type="file" id="img" name="img" accept="image/*">
                                                        
                                                        </form>
                                                    </td>
                                                    <td>
                                                        <select class="select-box hangTra" name="state" style="width:100%;height:35px;">
                                                            <option>3x2</option>
                                                            <option>4x6</option>
                                                        </select>
                                                    </td>
                                                    <td>
                                                        <input class="txt-input-table so-luong-tra" value="" style="width:100%;" placeholder="Số lượng trả" />
                                                    </td>
                                                    <td>
                                                          <select class="select-box hangTra" name="state" style="width:100%;height:35px;">
                                                            <option>1</option>
                                                            <option>2</option>
                                                        </select>
                                                    </td>
                                                    <td>
                                                        <input class="txt-input-table don-gia"  />
                                                    </td>
                                                    <td>
                                                        <input class="txt-input-table thanh-tien" />
                                                    </td>
                                                    <td>
                                                        <span class="icon-delete" onclick='deleteRow(this)'>X</span>
                                                    </td>
                                    </tr>`)
            // select hàng bán thay đổi hàng trả
            $('.hangBan').on('select2:select', function (e) {
                var data = $(this).select2('data')
                var hangBan = $(this).val();
                var hangBanText = data[0].text;

                var hangTra = "";
                var hangTraText = "";
                var tblElement = $(this);
                $.each(listHangHoa, function () {
                    if (this.ma_vt == hangBan) {
                        hangTra = this.ma_vo;
                        var apiGetDanhMucHangHoa = FDMModule.api._getDanhMucHangHoa({ PageNumber: 1, PageSize: 20, keyWord: hangTra });
                        global.callApi(apiGetDanhMucHangHoa, "GET", null, token, function (res) {
                            $.each(res, function () {
                                if (this.ma_vt == hangTra) {
                                    hangTraText = this.ten_vt;
                                    var newOption = new Option(hangTraText, hangTra, false, true);
                                    tblElement.closest('tr').find('.hangTra').append(newOption).trigger('change');

                                    return;
                                }
                            });
                        });
                    }
                });

            });

            $(".hangBan, .hangTra, .hangBanEdit, .hangTraEdit").select2({ width: '150px' });
            var listHangHoa = [];
            $('.hangBan, .hangTra, .hangBanEdit, .hangTraEdit').select2({
                ajax: {
                    url: '/api/FDM/GetDanhMucHangHoa',
                    dataType: 'json',
                    data: function (params) {
                        var query = {
                            keyWord: params.term,
                            pageNumber: 1,
                            pageSize: params.page * 10 || 10
                        }
                        return query;
                    },
                    processResults: function (data) {
                        listHangHoa = data;
                        var tempData = [];
                        item = {
                            "id": 0,
                            "text": 'Chọn mã hàng'
                        };
                        tempData.push(item);
                        var options = $(this);
                        $.each(data, function () {
                            item = {
                                "id": this.ma_vt,
                                "text": this.ten_vt
                            };
                            tempData.push(item);
                        });

                        return {
                            "results": tempData,
                            "pagination": {
                                "more": true
                            }
                        };
                    }
                }
            });

            $(".so-luong-ban").keyup(function () {
                var soluong = parseFloat($(this).val());
                var dongia = $(this).closest('tr').find('.don-gia').val();
                dongia = currencyToNumber(dongia);
                if (!isNaN(dongia) && !isNaN(soluong)) {
                    $(this).closest('tr').find('.thanh-tien').val(formatCurrency((soluong * dongia).toString()));
                } else {
                    $(this).closest('tr').find('.thanh-tien').val("");
                }
                tongTien();
            });

            $(".don-gia").keyup(function () {
                var dongia = $(this).val();
                dongia = currencyToNumber(dongia);
                var soluong = parseFloat($(this).closest('tr').find('.so-luong-ban').val());
                if (!isNaN(dongia) && !isNaN(soluong)) {
                    $(this).closest('tr').find('.thanh-tien').val(formatCurrency((soluong * dongia).toString()));
                } else {
                    $(this).closest('tr').find('.thanh-tien').val("");
                }
                tongTien();
                $(this).val(formatCurrency(this.value.replace(/[,]/g, '')));
            });
        });
    });

    $("#addRowEdit").click(function () {

        $("#tblEditHoaDon tbody").append(`<tr>
                                        <td>
                                            <select class="select-box hangBanEdit" name="state" style="width:100%;height:35px;">
                                            </select>
                                        </td>
                                        <td>
                                            <input class="txt-input-table so-luong-ban-edit" value="" placeholder="Số lượng bán" />
                                        </td>
                                        <td>
                                            <select class="select-box hangTraEdit" name="state" style="width:100%;height:35px;">
                                            </select>
                                        </td>
                                        <td>
                                            <input class="txt-input-table so-luong-tra-edit" value="" placeholder="Số lượng trả"/>
                                        </td>
                                        <td>
                                            <input class="txt-input-table don-gia-edit" value="" placeholder="Giá bán" />
                                        </td>
                                        <td>
                                            <input class="txt-input-table thanh-tien-edit" disabled value="" />
                                        </td>
                                        <td style="text-align: center">
                                                <span class="icon-delete" onclick='deleteRow(this)'>X</span>
                                        </td>
                                    </tr>`)

        var listHangHoa = [];

        $('.hangBanEdit, .hangTraEdit').select2({
            ajax: {
                url: '/api/FDM/GetDanhMucHangHoa',
                dataType: 'json',
                data: function (params) {
                    var query = {
                        keyWord: params.term,
                        pageNumber: 1,
                        pageSize: params.page * 10 || 10
                    }
                    return query;
                },
                processResults: function (data) {
                    listHangHoa = data;
                    var tempData = [];
                    item = {
                        "id": 0,
                        "text": 'Chọn mã hàng'
                    };
                    tempData.push(item);
                    var options = $(this);
                    $.each(data, function () {
                        item = {
                            "id": this.ma_vt,
                            "text": this.ten_vt
                        };
                        tempData.push(item);
                    });

                    return {
                        "results": tempData,
                        "pagination": {
                            "more": true
                        }
                    };
                }
            }
        });
        $('.hangBanEdit').on('select2:select', function (e) {
            var data = $(this).select2('data')
            var hangBan = $(this).val();
            var hangBanText = data[0].text;

            var hangTra = "";
            var hangTraText = "";
            var tblElement = $(this);
            $.each(listHangHoa, function () {
                if (this.ma_vt == hangBan) {
                    hangTra = this.ma_vo;
                    var apiGetDanhMucHangHoa = FDMModule.api._getDanhMucHangHoa({ PageNumber: 1, PageSize: 20, keyWord: hangTra });
                    global.callApi(apiGetDanhMucHangHoa, "GET", null, token, function (res) {
                        $.each(res, function () {
                            if (this.ma_vt == hangTra) {
                                hangTraText = this.ten_vt;
                                var newOption = new Option(hangTraText, hangTra, false, true);
                                tblElement.closest('tr').find('.hangTraEdit').append(newOption).trigger('change');

                                return;
                            }
                        });
                    });
                }
            });

        });
        $(".so-luong-ban-edit").keyup(function () {
            var soluong = parseFloat($(this).val());
            var dongia = $(this).closest('tr').find('.don-gia-edit').val();
            dongia = currencyToNumber(dongia);
            if (!isNaN(dongia) && !isNaN(soluong)) {
                $(this).closest('tr').find('.thanh-tien-edit').val(formatCurrency((soluong * dongia).toString()));
            } else {
                $(this).closest('tr').find('.thanh-tien-edit').val("");
            }
            tongTienEdit();
        });
        $(".don-gia-edit").keyup(function () {
            var dongia = $(this).val();
            dongia = currencyToNumber(dongia);
            var soluong = parseFloat($(this).closest('tr').find('.so-luong-ban-edit').val());
            if (!isNaN(dongia) && !isNaN(soluong)) {
                $(this).closest('tr').find('.thanh-tien-edit').val(formatCurrency((soluong * dongia).toString()));
            } else {
                $(this).closest('tr').find('.thanh-tien-edit').val("");
            }
            tongTien();
            $(this).val(formatCurrency(this.value.replace(/[,]/g, '')));
        });
    });

    // add drop box tuyến khách hàng table Add Hóa đơn
    $('#tuyenKhachHang').select2({
        ajax: {
            url: '/api/FDM/GetDanhMucNhomKhachHang',
            dataType: 'json',
            data: function (params) {
                var query = {
                    keyWord: params.term,
                    pageNumber: 1,
                    pageSize: params.page * 10 || 10
                }
                return query;
            },
            processResults: function (data) {
                var tempData = [];
                item = {
                    "id": 0,
                    "text": 'Chọn tuyến khách hàng'
                };
                tempData.push(item);
                var options = $('#tuyenKhachHang');
                $.each(data.listDanhMucNhomKhachHang, function () {
                    item = {
                        "id": this.ma_nh,
                        "text": this.ten_nh
                    };
                    tempData.push(item);
                });

                return {
                    "results": tempData,
                    "pagination": {
                        "more": data.pagingInfo.currentPage < data.pagingInfo.totalPages
                    }
                };
            }
        },
        allowClear: true,
        placeholder: "Tìm tuyến khách",
    });

    $('#tuyenKhachHang').on('select2:select', function (e) {
        var tuyenKhachHang = $('#tuyenKhachHang').val();
        if (tuyenKhachHang!=0) {
            $('#maKhachHang').find('option').remove().end();
            initDropdownKhachHang(tuyenKhachHang);

            $('#tenKhachHang').val("");
        }
      
    });

    $('.hangBan').on('select2:select', function (e) {
        var data = $(this).select2('data')
        var hangBan = $(this).val();
        var hangBanText = data[0].text;

        var hangTra = "";
        var hangTraText = "";
        var tblElement = $(this);
        $.each(listHangHoa, function () {
            if (this.ma_vt == hangBan) {
                hangTra = this.ma_vo;
                var apiGetDanhMucHangHoa = FDMModule.api._getDanhMucHangHoa({ PageNumber: 1, PageSize: 20, keyWord: hangTra });
                global.callApi(apiGetDanhMucHangHoa, "GET", null, token, function (res) {
                    $.each(res, function () {
                        if (this.ma_vt == hangTra) {
                            hangTraText = this.ten_vt;
                            var newOption = new Option(hangTraText, hangTra, false, true);
                            tblElement.closest('tr').find('.hangTra').append(newOption).trigger('change');

                            return;
                        }
                    });
                });
            }
        });

        //$(this).closest('tr').find('.don-gia').val(data[0]);
    });

    $('.hangBanEdit').on('select2:select', function (e) {
        var data = $(this).select2('data')
        var hangBan = $(this).val();
        var hangBanText = data[0].text;

        var hangTra = "";
        var hangTraText = "";
        var tblElement = $(this);
        $.each(listHangHoa, function () {
            if (this.ma_vt == hangBan) {
                hangTra = this.ma_vo;
                var apiGetDanhMucHangHoa = FDMModule.api._getDanhMucHangHoa({ PageNumber: 1, PageSize: 20, keyWord: hangTra });
                global.callApi(apiGetDanhMucHangHoa, "GET", null, token, function (res) {
                    $.each(res, function () {
                        if (this.ma_vt == hangTra) {
                            hangTraText = this.ten_vt;
                            var newOption = new Option(hangTraText, hangTra, false, true);
                            tblElement.closest('tr').find('.hangTraEdit').append(newOption).trigger('change');

                            return;
                        }
                    });
                });
            }
        });

    });

    $('.hangBan, .hangTra').select2({
        ajax: {
            url: '/api/FDM/GetDanhMucHangHoa',
            dataType: 'json',
            data: function (params) {
                var query = {
                    keyWord: params.term,
                    pageNumber: 1,
                    pageSize: params.page * 10 || 10
                }
                return query;
            },
            processResults: function (data) {
                listHangHoa = data;
                var tempData = [];
                item = {
                    "id": 0,
                    "text": 'Chọn mã hàng'
                };
                tempData.push(item);
                var options = $(this);
                $.each(data, function () {
                    item = {
                        "id": this.ma_vt,
                        "text": this.ten_vt
                    };
                    tempData.push(item);
                });

                return {
                    "results": tempData,
                    "pagination": {
                        "more": true
                    }
                };
            }
        }
    });

    $(".so-luong-ban").keyup(function () {
        var soluong = parseFloat($(this).val());
        var dongia = $(this).closest('tr').find('.don-gia').val();
        dongia = currencyToNumber(dongia);
        if (!isNaN(dongia) && !isNaN(soluong)) {
            $(this).closest('tr').find('.thanh-tien').val(formatCurrency((soluong * dongia).toString()));
        } else {
            $(this).closest('tr').find('.thanh-tien').val("");
        }
        tongTien();
    });

    $(".don-gia").keyup(function () {
        var dongia = $(this).val();
        dongia = currencyToNumber(dongia);
        var soluong = parseFloat($(this).closest('tr').find('.so-luong-ban').val());
        if (!isNaN(dongia) && !isNaN(soluong)) {
            $(this).closest('tr').find('.thanh-tien').val(formatCurrency((soluong * dongia).toString()));
        } else {
            $(this).closest('tr').find('.thanh-tien').val("");
        }
        tongTien();
    });

    /// add hóa đơn
    //$('#btnAddHoaDon').click(function () {
    //    AddHoaDon();
    //});

    // Edit Hoa Don
    $('#btnEditHoaDon').click(function () {
        EditHoaDon();
    });

    // auto complete số hóa đơn
    $("#soHDFilter").keyup(function () {
        delay(searchSoHoaDon, 700);
    });


    // out focus filter
    $(".filter .input-filter").focusout(function () {
        var soHoaDon = $('#soHDFilter').val();
        var maKh = $('#maKHFilter').val();
        var ngay_lap = $("#dpNgayLapFilter").val().replace(/[\/]/g, '_');
        // đổi thành yyyy_MM_dd gửi lên sv
        if (ngay_lap != "") {
            var paths = ngay_lap.split('_');
            ngay_lap = paths[2] + '_' + paths[1] + '_' + paths[0];
        }
        GetDanhSachHoaDon(1, 10, soHoaDon, maKh, ngay_lap);
    });

    $('.filter .input-filter').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            // force focusout
            $(this).blur();
        }
    });

    // auto complete số hóa đơn
    $("#maKHFilter").keyup(function () {
        searchMaKhachHang();
    });

    // click row load modal
    $("#tblDanhSachHoaDon").on("click", "tbody tr", function () {
        $("#tblDanhSachHoaDon tbody tr").removeClass("row-selected");
        $(this).addClass("row-selected");
    });

    $(".btn-edit-hoadon").on("click", function () {
        var selectedRow = $("#tblDanhSachHoaDon tbody tr.row-selected");
        if (selectedRow.length == 0) {
            alert("Bạn cần chọn Hóa đơn để chỉnh sửa");
        } else {
            var maHoaDon = $('#tblDanhSachHoaDon tbody tr.row-selected').data("id");
            $('#editHoaDonModal').data('id', maHoaDon);
            GetHoaDonEdit(maHoaDon);
        }
    });
    $(".btn-delete-hoadon").on("click", function () {
        var selectedRow = $("#tblDanhSachHoaDon tbody tr.row-selected");
        if (selectedRow.length == 0) {
            alert("Bạn cần chọn Hóa đơn để xóa");
        } else {
            var maHoaDon = $('#tblDanhSachHoaDon tbody tr.row-selected').data("id");
            DeleteHoaDon(maHoaDon);
        }
    });

    $("#tblDanhSachHoaDon").on("dblclick", "tbody tr", function () {
        var maHoaDon = $(this).data("id");
        $('#editHoaDonModal').data('id', maHoaDon);
        GetHoaDonEdit(maHoaDon);

    });
    $('#tienThu, .don-gia, .thanh-tien').each(function () {
        $(this).on('input', function (e) {
            $(this).val(formatCurrency(this.value.replace(/[,]/g, '')));
        }).on('keypress', function (e) {
            if (!$.isNumeric(String.fromCharCode(e.which))) e.preventDefault();
        }).on('paste', function (e) {
            var cb = e.originalEvent.clipboardData || window.clipboardData;
            if (!$.isNumeric(cb.getData('text'))) e.preventDefault();
        });
    })

 

});
//tìm kiếm mã khách hàng
function searchMaKhachHang() {
    let keySearch = $('#maKHFilter').val();
    $.ajax(`/api/FDM/GetDanhSachMaKhachHang?keyWord=` + keySearch)
        .done(function (result) {
            $("#maKHFilter").autocomplete({
                source: result
            });
        })
        .fail(function (error) {
        });
};
// tìm kiếm hóa đơn
function searchSoHoaDon() {
    let keySearch = $('#soHDFilter').val();
    $.ajax(`/api/FDM/GetDanhSachSoHoaDon?keyWord=` + keySearch)
        .done(function (result) {
            $("#soHDFilter").autocomplete({
                source: result
            });
        })
        .fail(function (error) {
        });
};

// Lấy thông tin hóa đơn edit
function GetHoaDonEdit(maHoaDon) {
    showLoadingScreen();
    var apiGetChiTietHoaDon = FDMModule.api._getChiTietHoaDon({ so_ct: maHoaDon });
    global.callApi(apiGetChiTietHoaDon, "GET", null, "", function (res) {
        var dsChiTietHoaDon = res.danhSachChiTietHoaDon;
        var hoaDon = res.hoaDon;
        $('#tongTienEdit').text(formatCurrency(hoaDon.t_tien.toString()));
        $('#dpNgayLapEdit').val(formatDate(hoaDon.ngay_ct));
        $('#tienThuEdit').val(formatCurrency(hoaDon.t_thu.toString()));
        $('#txtDienGiaiEdit').val(hoaDon.dien_giai);
        initDropdownTuyenKhachHang('#tuyenKhachHangEdit', hoaDon.ma_nh);

        $('.hangBanEdit').on('select2:select', function (e) {
            var data = $(this).select2('data')
            var hangBan = $(this).val();
            var hangBanText = data[0].text;

            var hangTra = "";
            var hangTraText = "";
            var tblElement = $(this);
            $.each(listHangHoa, function () {
                if (this.ma_vt == hangBan) {
                    hangTra = this.ma_vo;
                    var apiGetDanhMucHangHoa = FDMModule.api._getDanhMucHangHoa({ PageNumber: 1, PageSize: 20, keyWord: hangTra });
                    global.callApi(apiGetDanhMucHangHoa, "GET", null, token, function (res) {
                        $.each(res, function () {
                            if (this.ma_vt == hangTra) {
                                hangTraText = this.ten_vt;
                                var newOption = new Option(hangTraText, hangTra, false, true);
                                tblElement.closest('tr').find('.hangTraEdit').append(newOption).trigger('change');

                                return;
                            }
                        });
                    });
                }
            });

        });

        initDropdownMaKhachHang('#maKhachHangEdit', hoaDon.ma_kh);

        // template cho row chi tiết hóa đơn

        // duyệt qua list chi tiết hóa đơn, rồi binding từng dòng dữ liệu vào template => tr của tbody

        var templateTr = `
                                    <tr>
                                        <td>
                                            <select class="select-box hangBanEdit" id="drpHangBanEdit-{{i}}" name="state" style="width:100%;height:35px;">
                                            </select>
                                        </td>
                                        <td>
                                            <input class="txt-input-table so-luong-ban-edit" value="" />
                                        </td>
                                        <td>
                                            <select class="select-box hangTraEdit" id="drpHangTraEdit-{{i}}" name="state" style="width:100%;height:35px;">
                                        </select>
                                        </td>
                                        <td>
                                            <input class="txt-input-table so-luong-tra-edit" value="" />
                                        </td>
                                        <td>
                                            <input class="txt-input-table don-gia-edit" value="" />
                                        </td>
                                        <td>
                                            <input class="txt-input-table thanh-tien-edit" disabled />
                                        </td>
                                        <td>
                                            <span class="icon-delete" onclick='deleteRow(this)'>X</span>
                                        </td>
                                    </tr>`;
        $("#tblEditHoaDon tbody").empty();
        var ten;
        for (var i = 0; i < dsChiTietHoaDon.length; i++) {
            // set Id riêng cho từng row để handle binding và tạo select,....
            var tr = templateTr.replace(/{{i}}/g, i);

            $("#tblEditHoaDon tbody").append(tr);

            ////binding value vào
            //$("#txtSoLuongBanEdit-" + i).val(dsChiTietHoaDon[i].so_luong_ban);

            // sự kiện cho select2....
            var ma_vt_ban = dsChiTietHoaDon[i].ma_vt_ban;
            initDropdownHangHoa("#drpHangBanEdit-" + i, ma_vt_ban);
           
			$('.hangBanEdit').on('select2:select', function (e) {
                    var data = $(this).select2('data')
                    var hangBan = $(this).val();
                    var hangBanText = data[0].text;

                    var hangTra = "";
                    var hangTraText = "";
                    var tblElement = $(this);
                    $.each(listHangHoa, function () {
                        if (this.ma_vt == hangBan) {
                            hangTra = this.ma_vo;
                            var apiGetDanhMucHangHoa = FDMModule.api._getDanhMucHangHoa({ PageNumber: 1, PageSize: 20, keyWord: hangTra });
                            global.callApi(apiGetDanhMucHangHoa, "GET", null, token, function (res) {
                                $.each(res, function () {
                                    if (this.ma_vt == hangTra) {
                                        hangTraText = this.ten_vt;
                                        var newOption = new Option(hangTraText, hangTra, false, true);
                                        tblElement.closest('tr').find('.hangTraEdit').append(newOption).trigger('change');

                                        return;
                                    }
                                });
                            });
                        }
                    });

                });

            initDropdownHangHoa("#drpHangTraEdit-" + i, dsChiTietHoaDon[i].ma_vt_tra);
            //$("#drpHangBanEdit-" + i).val(ma_vt_ban).trigger("change");

            $("#drpHangBanEdit-" + i).closest('tr').find('.so-luong-ban-edit').val(dsChiTietHoaDon[i].so_luong_ban);
            $("#drpHangBanEdit-" + i).closest('tr').find('.so-luong-tra-edit').val(dsChiTietHoaDon[i].so_luong_tra);
            $("#drpHangBanEdit-" + i).closest('tr').find('.don-gia-edit').val(formatCurrency(dsChiTietHoaDon[i].gia + ""));
            $("#drpHangBanEdit-" + i).closest('tr').find('.thanh-tien-edit').val(formatCurrency(dsChiTietHoaDon[i].tien + ""));
        }

		 $('#tblEditHoaDon tr').each(function myfunction() {

        });
        $('#editHoaDonModal').modal();
        $(".so-luong-ban-edit").keyup(function () {
            var soluong = parseFloat($(this).val());
            var dongia = $(this).closest('tr').find('.don-gia-edit').val();
            dongia = currencyToNumber(dongia);
            if (!isNaN(dongia) && !isNaN(soluong)) {
                $(this).closest('tr').find('.thanh-tien-edit').val(formatCurrency((soluong * dongia).toString()));
            } else {
                $(this).closest('tr').find('.thanh-tien-edit').val("");
            }
            tongTienEdit();
        });
        
        $(".don-gia-edit").keyup(function () {
            var dongia = $(this).val();
            dongia = currencyToNumber(dongia);
            var soluong = parseFloat($(this).closest('tr').find('.so-luong-ban-edit').val());
            if (!isNaN(dongia) && !isNaN(soluong)) {
                $(this).closest('tr').find('.thanh-tien-edit').val(formatCurrency((soluong * dongia).toString()));
            } else {
                $(this).closest('tr').find('.thanh-tien-edit').val("");
            }
            tongTienEdit()
            $(this).val(formatCurrency(this.value.replace(/[,]/g, '')));
        });
        hideLoadingScreen();
    });
}
// Xóa hóa đơn
function DeleteHoaDon(maHoaDon) {
    var result = confirm("Bạn chắc chắn muốn xóa hóa đơn không?");
    if (result) {
        showLoadingScreen();
        var apiDeleteHoaDon = FDMModule.api._deleteHoadon({ so_ct: maHoaDon });
        global.callApi(apiDeleteHoaDon, "POST", null, "", function (res) {
            if (!res) {
                alert("Xóa Hóa đơn không thành công, vui lòng kiểm tra dữ liệu đầu vào");
            } else {
                alert('Xóa hóa đơn thành công');
                location.replace("/");
            }
            hideLoadingScreen();
        });
    }
  
}
// lấy mã khách hàng add hóa đơn
function initDropdownKhachHang(tuyenKhachHang) {
    $('#maKhachHang').select2({
        ajax: {
            url: '/api/FDM/GetDanhMucKhachHang',
            dataType: 'json',
            data: function (params) {
                var query = {
                    keyWord: params.term,
                    pageNumber: params.page,
                    pageSize: params.page * 10 || 10,
                    maNhomKhachHang: tuyenKhachHang
                }
                return query;
            },
            //minimumResultsForSearch: Infinity,
            processResults: function (data) {
                var tempData = [];
                var options = $('#maKhachHang');
                $.each(data.listDanhMucKhachHang, function () {
                    item = {
                        "id": this.ma_kh,
                        "text": this.ma_kh
                    };
                    tempData.push(item);
                });

                return {
                    "results": tempData,
                    "pagination": {
                        "more": data.pagingInfo.currentPage < data.pagingInfo.totalPages
                    }
                };
            },
            //maximumSelectionSize: 1
        },
        placeholder: "Tìm mã khách, tên",
    });
}
function GetDanhSachHoaDon(pageNumber = 1, pageSize = 10, so_ct = "", ma_kh = "", ngay_lap = "") {
    ///// Load data from server

    // define template table
    var templateTable = $("#templateBodyTable").html();

    // api được lấy từ obj đã được định nghĩa, truyền vào obj phân trang
    var apiGetDanhSachHoaDon = FDMModule.api._getDanhSachHoaDon({ PageNumber: 1, PageSize: pageSize, so_ct: so_ct, ma_kh: ma_kh, ngay_lap: ngay_lap });


    // define sự kiện paging để lấy data paging từ server
    var callBackPaging = function (selectedPage) {
        var apiGetDanhSachHoaDon = FDMModule.api._getDanhSachHoaDon({ PageNumber: selectedPage, PageSize: pageSize, so_ct: so_ct, ma_kh: ma_kh });
        showLoadingScreen();
        global.callApi(apiGetDanhSachHoaDon, "GET", null, "", function (res) {
            $.each(res.listHoaDon, function (i, hoaDon) {
                hoaDon.t_tien = formatCurrency(hoaDon.t_tien + "");
                hoaDon.t_thu = formatCurrency(hoaDon.t_thu + "");
            });
            var tableConfig = {
                data: { Items: res.listHoaDon, TotalItems: res.pagingInfo.totalItems },
                pageSizeDefault: pageSize,
            };
            tbl2.init(tableConfig);

            hideLoadingScreen();
        });
    }

    showLoadingScreen();
    // Lấy data từ server, khởi tạo config và render table
    global.callApi(apiGetDanhSachHoaDon, "GET", null, token, function (res) {
        $.each(res.listHoaDon, function (i, hoaDon) {
            hoaDon.t_tien = formatCurrency(hoaDon.t_tien + "");
            hoaDon.t_thu = formatCurrency(hoaDon.t_thu + "");
        });
        var tableConfig = {
            tableContainer: '.tbl-hd',
            tableId: '#tblDanhSachHoaDon',
            data: { Items: res.listHoaDon, TotalItems: res.pagingInfo.totalItems },
            templateTr: templateTable,
            callBackSelectPage: function (selectedPage) {
                callBackPaging(selectedPage)
            },
            pageSizeDefault: pageSize,
        };
        tbl2 = tvTablePagination(tableConfig);
        tbl2.render();
        hideLoadingScreen();
    });

}
// show dropbox hàng bán,trả edit
var listHangHoa = [];
function initDropdownHangHoa(element, ma_vt) {
    var getMaHangBanApi = FDMModule.api._getDanhMucHangHoa({ pageNumber: 1, pageSize: 5000 });

    var token = global.getCookie("auth-jwt");
    global.callApi(getMaHangBanApi, "GET", null, null, function (data) {
        var loadData = data;
        listHangHoa = data;
        $(element).select2();

        var options = $(element);
        $.each(loadData, function () {
            options.append($("<option />").val(this.ma_vt).text(this.ten_vt));
        });
        $(element).val(ma_vt).trigger("change");
    });
}

// add dropbox tuyến khách hàng edit
function initDropdownTuyenKhachHang(element, tuyen_kh) {
    var getTuyenKhachHangApi = FDMModule.api._getDanhSachTuyenKhachHang({ pageNumber: 1, pageSize: 100 });

    var token = global.getCookie("auth-jwt");
    global.callApi(getTuyenKhachHangApi, "GET", null, null, function (data) {
        var loadData = data.listDanhMucNhomKhachHang;
        $(element).select2();

        var options = $(element);
        $.each(loadData, function () {
            options.append($("<option />").val(this.ma_nh).text(this.ten_nh));
        });
        if (tuyen_kh!=0) {
            $('#tuyenKhachHangEdit').val(tuyen_kh).trigger('change');
        }
    
    });
}
// add dropbox Mã khác hàng edit
function initDropdownMaKhachHang(element, ma_kh) {
    var getMaKhachHangApi = FDMModule.api._getDanhMucKhachHang({ pageNumber: 1, pageSize: 10000 });

    var token = global.getCookie("auth-jwt");
    global.callApi(getMaKhachHangApi, "GET", null, null, function (data) {
        var loadData = data.listDanhMucKhachHang;
        $(element).select2();

        var options = $(element);
        $.each(loadData, function () {
            options.append($("<option />").val(this.ma_kh).text(this.ma_kh));
        });

        // lúc này mới lấy đủ ds mã khách hàng và tạo select2
        // tiếp theo mới set selected value cho nó đc
        if (ma_kh!=0) {
            $('#maKhachHangEdit').val(ma_kh).trigger('change');
        }
       

        // rồi đổi input tên khách hàng theo giá trị.

        //truyền thêm cái ma_kh vào
        ChangeCustomerName(ma_kh);
    });
}
// Thêm hóa đơn
function AddHoaDon() {
    var isValid = true;
    var getSoCt = FDMModule.api._getMaHoaDonMoi();

    global.callApi(getSoCt, "GET", null, "", function (data) {
        var so_ct = data;
        var date = $('#dpNgayLap').val();
        var ngayLap = date.replace(/(\d\d)\/(\d\d)\/(\d{4})/, "$3-$2-$1") + 'T00:00:00';
        var tienThu = parseFloat($('#tienThu').val().replace(/[,]/g, '')) || 0;
        var tongTien = parseFloat(currencyToNumber($('#tongTien').text()));
        var maKhachHang = $('#maKhachHang').val();
        // validate
        if (date==null || date == "") {
            $('#dpNgayLap').addClass('error-border');
            isValid = false;
        } else {
            $('#dpNgayLap').removeClass('error-border');
        }
        if (isNullOrEmpty(maKhachHang) || maKhachHang==0) {
            $('#maKhachHang').closest('div').find('.select2-selection--single').addClass('error-border');
            isValid = false;
        } else {
            $('#maKhachHang').closest('div').find('.select2-selection--single').removeClass('error-border');
        }
        
        var dienGiai = $('#txtDienGiai').val();
        var apiAddHoaDon = FDMModule.api._addHoaDon();
        var hoaDonAdd = {
            so_ct: so_ct,
            ma_kh: maKhachHang,
            dien_giai: dienGiai,
            t_thu: tienThu,
            t_tien: tongTien,
            ngay_ct: ngayLap
        }
        var isValidChiTiet= getDanhSachChiTietHoaDonAdd();

        if (isValid == true && isValidChiTiet == true) {
            showLoadingScreen();
            global.callApi(apiAddHoaDon, "POST", { HoaDon: hoaDonAdd, danhSachChiTietHoaDon: danhSachChiTietHoaDonAdd }, "", function (res) {
                if (!res) {
                    alert("Tạo Hóa đơn không thành công, vui lòng kiểm tra dữ liệu đầu vào");
                } else {
                    alert('Thêm hóa đơn thành công');
                    location.replace("/");
                }
                hideLoadingScreen();
            });
        } else {
            $('')
        }
     

    });
}
// Sửa hóa đơn
function EditHoaDon() {
    var isValid = true;
    var so_ct = $('#editHoaDonModal').data('id');
    var date = $('#dpNgayLapEdit').val();
    var ngayLap = date.replace(/(\d\d)\/(\d\d)\/(\d{4})/, "$3-$2-$1") + 'T00:00:00';
    var tienThu = parseFloat($('#tienThuEdit').val().replace(/[,]/g, '')) || 0;
    var tongTien = parseFloat(currencyToNumber($('#tongTienEdit').text()));;
    var maKhachHang = $('#maKhachHangEdit').val();
    var dienGiai = $('#txtDienGiaiEdit').val();
    // validate
    if (date == null || date == "") {
        $('#dpNgayLapEdit').addClass('error-border');
        isValid = false;
    } else {
        $('#dpNgayLapEdit').removeClass('error-border');
    }
    if (isNullOrEmpty(maKhachHang) || maKhachHang == 0) {
        $('#maKhachHangEdit').closest('div').find('.select2-selection--single').addClass('error-border');
        isValid = false;
    } else {
        $('#maKhachHangEdit').closest('div').find('.select2-selection--single').removeClass('error-border');
    }
    var isValidChiTiet = getDanhSachChiTietHoaDonEdit();
    var apiEditHoaDon = FDMModule.api._editHoaDon();
    var hoaDonEdit = {
        so_ct: so_ct,
        ma_kh: maKhachHang,
        dien_giai: dienGiai,
        t_thu: tienThu,
        t_tien: tongTien,
        ngay_ct: ngayLap
    }
    getDanhSachChiTietHoaDonEdit();
    if (isValid == true && isValidChiTiet==true) {
            showLoadingScreen();
        global.callApi(apiEditHoaDon, "POST", { HoaDon: hoaDonEdit, danhSachChiTietHoaDon: danhSachChiTietHoaDonEdit }, "", function (data) {
            if (data === true) {
                alert('Sửa hóa đơn thành công');
                location.replace("/");
            } else {
                alert('Sửa hóa đơn không thành công');
            }
            hideLoadingScreen();
        });
    }
  

}
var danhSachChiTietHoaDonAdd = [];
var danhSachChiTietHoaDonEdit = [];
//get danh sach chi tiết hóa đơn add
function getDanhSachChiTietHoaDonAdd() {
    danhSachChiTietHoaDonAdd = [];
    var isValid = true;
    $('#tblAddHoaDon tbody tr').each(function () {
       
        //// validate
        //if ((maHangBan == null || maHangBan == "") && (maHangTra == null || maHangTra == "")) {
        //    $(this).find('.hangBan').closest('td').find('.select2-selection--single').addClass('error-border');
        //    $(this).find('.hangTra').closest('td').find('.select2-selection--single').addClass('error-border');
        //    return false;
        //} else if ((maHangBan != null || maHangBan != "") && isNaN(soLuongBan)) {
        //    $(this).find('.so-luong-ban').addClass('error-border');
        //} 
        //var chiTietHoaDon = {
        //    ma_chi_tiet_ct: 0,
        //    so_ct: "",
        //    ma_vt_ban: maHangBan,
        //    so_luong_ban: soLuongBan,
        //    ma_vt_tra: maHangTra,
        //    so_luong_tra: soLuongTra,
        //    gia: donGia,
        //    tien: thanhTien,
        //}
        //danhSachChiTietHoaDonAdd.push(chiTietHoaDon);
        var isValidRow = validateDanhSachChiTietAdd(this);
        if (isValidRow == false) {
            isValid = false
        };
    });
    return isValid;
}
// validate Danh sách chi tiết add hóa đơn
function validateDanhSachChiTietAdd(element) {
    var isValid = true;
    let maHangBan = $(element).find('.hangBan').val();
    let soLuongBan = parseFloat($(element).find('.so-luong-ban').val());
    let maHangTra = $(element).find('.hangTra').val();
    let soLuongTra = parseFloat($(element).find('.so-luong-tra').val());
    let donGia = parseFloat(currencyToNumber($(element).find('.don-gia').val()));
    let thanhTien = parseFloat(currencyToNumber($(element).find('.thanh-tien').val()));

    if (((!isNullOrEmpty(maHangBan) || maHangBan == '0')) && (isNullOrEmpty(maHangTra) || maHangTra == '0')) {
        $(element).find('.hangBan').closest('td').find('.select2-selection--single').addClass('error-border');
        $(element).find('.hangTra').closest('td').find('.select2-selection--single').addClass('error-border');
        isValid = false;
    } else if ((!isNullOrEmpty(maHangBan) || maHangBan==0) && (isNaN(soLuongBan))) {
        $(element).find('.so-luong-ban').addClass('error-border');
        isValid = false;
    } else if ((!isNullOrEmpty(maHangTra) || maHangTra==0) && isNaN(soLuongTra)) {
        $(element).find('.so-luong-tra').addClass('error-border');
        isValid = false;
    }
    if (isValid==true) {
        var chiTietHoaDon = {
            ma_chi_tiet_ct: 0,
            so_ct: "",
            ma_vt_ban: maHangBan,
            so_luong_ban: soLuongBan,
            ma_vt_tra: maHangTra,
            so_luong_tra: soLuongTra,
            gia: donGia,
            tien: thanhTien,
        }
        danhSachChiTietHoaDonAdd.push(chiTietHoaDon);
    }
    return isValid;
}
// kiểm tra null or empty
function isNullOrEmpty(val) {
    return ((val == null || val == ""));

}
// get danh sách chi tiết hóa đơn edit
function getDanhSachChiTietHoaDonEdit() {
    danhSachChiTietHoaDonEdit = [];
    var isValid = true;
    $('#tblEditHoaDon tbody tr').each(function () {
        var isValidRow = validateDanhSachChiTietEdit(this);
        if (isValidRow == false) {
            isValid = false
        };
    });
    return isValid;
}
// validate Danh sách chi tiết add hóa đơn
function validateDanhSachChiTietEdit(element) {
    var isValid = true;
    let maHangBan = $(element).find('.hangBanEdit').val();
    let soLuongBan = parseFloat($(element).find('.so-luong-ban-edit').val());
    let maHangTra = $(element).find('.hangTraEdit').val();
    let soLuongTra = parseFloat($(element).find('.so-luong-tra-edit').val());
    let donGia = parseFloat(currencyToNumber($(element).find('.don-gia-edit').val()));
    let thanhTien = parseFloat(currencyToNumber($(element).find('.thanh-tien-edit').val()));

    if (((!isNullOrEmpty(maHangBan) || maHangBan == '0')) && (isNullOrEmpty(maHangTra) || maHangTra == '0')) {
        $(element).find('.hangBanEdit').closest('td').find('.select2-selection--single').addClass('error-border');
        $(element).find('.hangTraEdit').closest('td').find('.select2-selection--single').addClass('error-border');
        isValid = false;
    } else if ((!isNullOrEmpty(maHangBan) || maHangBan == 0) && (isNaN(soLuongBan))) {
        $(element).find('.so-luong-ban-edit').addClass('error-border');
        isValid = false;
    } else if ((!isNullOrEmpty(maHangTra) || maHangTra == 0) && isNaN(soLuongTra)) {
        $(element).find('.so-luong-tra-edit').addClass('error-border');
        isValid = false;
    }
    if (isValid == true) {
        var chiTietHoaDon = {
            ma_chi_tiet_ct: 0,
            so_ct: "",
            ma_vt_ban: maHangBan,
            so_luong_ban: soLuongBan,
            ma_vt_tra: maHangTra,
            so_luong_tra: soLuongTra,
            gia: donGia,
            tien: thanhTien,
        }
        danhSachChiTietHoaDonEdit.push(chiTietHoaDon);
    }
    return isValid;
}
// đổi sang dd/mm/yyyy
function formatDate(input) {
    var datePart = input.substring(0, input.indexOf('T')).match(/\d+/g),
        year = datePart[0], // get only two digits
        month = datePart[1], day = datePart[2];
    return day + '/' + month + '/' + year;
}
// đổi tên mã khách hàng
function ChangeCustomerName(keyWord) {
    if (keyWord!=0) {
        var getMaKhachHang = FDMModule.api._getDanhMucKhachHang({ PageNumber: 1, PageSize: 1, maNhomKhachHang: "", keyWord: keyWord });

        global.callApi(getMaKhachHang, "GET", null, "", function (data) {
            $('#tenKhachHangEdit').val(data.listDanhMucKhachHang[0].ten_kh + "");
        });
    } else {
        $('#tenKhachHangEdit').val("");
    }

  
}

function currencyToNumber(curentcyValue) {
    return curentcyValue.replace(/[,]/g, '');
}

function deleteRow(element) {
    $(element).closest('tr').remove();
    tongTien();
    tongTienEdit();
}
function formatCurrency(number) {
    var n = number.split('').reverse().join("");
    var n2 = n.replace(/\d\d\d(?!$)/g, "$&,");
    return n2.split('').reverse().join('');
}
function tongTien() {
    var sum = 0;
    $('#tblAddHoaDon .thanh-tien').each(function () {
        var combat = $(this).val();
        combat = currencyToNumber(combat);

        if (!isNaN(combat) && combat.length !== 0) {
            sum += parseFloat(combat);
        }
    });

    $('#tongTien').text(formatCurrency(sum.toString()));
}

function tongTienEdit() {
    var sum = 0;
    $('#tblEditHoaDon .thanh-tien-edit').each(function () {
        var combat = $(this).val();
        combat = currencyToNumber(combat);
        if (!isNaN(combat) && combat.length !== 0) {
            sum += parseFloat(combat);
        }
    });
    $('#tongTienEdit').text(formatCurrency(sum.toString()));
}

$(document).ready(function () {
    $("#btnAddHoaDon").click(function () {
        let length = $("#tblAddHoaDon input[type=file]").length;

        //let sohoadon = "hoadonfake";
        // userid = "userid";

        let url = location.href.substring(0, location.href.lastIndexOf('/')) + "/image/upload2";

            //"/api/account/upfile?sohoadon=" + sohoadon + "&userid=" + userid;

  

        for (let i = 0; i < length; i++) {  
            let image = $('input[type=file]')[i].files[0];

            let formData = new FormData();
            formData.append('image_' + i, image);
            debugger;
            $.ajax({
                url: url,
                data: formData,
                type: 'POST',
                contentType: false,
                processData: false,
                success: function (result, status, xhr) {
                    alert("");
                    alert(result);
                  
                },
                error: function (xhr, status, error) {
                    alert("");
                    alert(status);
                    alert(error);
                }
            });
        }


        //let length = $("#tblAddHoaDon input[type=file]").length;

        //for (let i = 0; i < length; i++) {
        //    let input = $("#tblAddHoaDon input[type=file]").get(i);
        //    let file = input.files[0];
        //    console.log(file.name);

        //    let formData = new FormData();
        //    formData.append("file", file);

        //    try {
        //        const response = await fetch('api/image/upload', {
        //            method: 'POST',
        //            body: formData,
        //            headers: {
        //                'Content-Type': 'multipart/form-data'
        //            },

        //        }).then(function (response) {
        //            console.log(response.status)
        //            console.log("response");
        //            console.log(response)
        //        });

        //    } catch (error) {
        //        console.error('Error:', error);
        //    }
        //}

        //let url = location.href.substring(0, location.href.lastIndexOf('/')) + "/image/upload";


        //axios.post("/api/account/upfile", formData, {
        //    headers: {
        //         'Content-Type' : 'multipart/form-data'
        //    }
        //});

      
        
    })
});
