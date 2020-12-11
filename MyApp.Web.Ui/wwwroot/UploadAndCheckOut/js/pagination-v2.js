//------------------------------------------------------------------------------------------//
//	paginationv2 v2.0																			//
//																							//
//------------------------------------------------------------------------------------------//

(function ($) {

    $.fn.paginationv2 = function (options) {

        var defaults = {
            totalItems: 1, //kích cỡ trang
            currentPage: 1, //trang hiện tại
            pageSize: 10,
            pageSizeToDisplay: 4, //số trang sẽ hiển thị trên phân trang
            customClass: {
                currentPage: 'currentPage'
            },
            selectPageCallback: function () { }
        };

        var options = $.extend(defaults, options);

        //console.log(`options`, options);

        return this.each(function () {
            var selector = $(this);
            var pageCounter = 1;
            var totalPages = Math.ceil(options.totalItems / options.pageSize);

            if (options.currentPage > totalPages) {
                console.warn('số trang nhập lớn hơn tổng số trang nên sẽ được thiết lập là trang cuối');
                options.currentPage = totalPages;
            }

            var ulEl = document.createElement("ul");
            ulEl.classList.add('paginationNavigator', 'paging');

            updateCurrentPage(options.currentPage);

            //số trang lớn hơn 1 thì mới tạo trang
            if (totalPages > 1) {
                //nếu số trang lớn hơn pageSizeToDisplay thì hiển thị phím next, back
                if (options.currentPage > 1) {
                    if (totalPages > options.pageSizeToDisplay) {
                        var liEl = document.createElement("li");
                        liEl.onclick = (function () {
                            return function () {
                                options.selectPageCallback(1);

                                options.currentPage = 1;
                                render();
                            }
                        })(1);
                        var aEl = document.createElement("a");
                        aEl.style.cursor = 'pointer';
                        aEl.innerHTML = '«';
                        liEl.appendChild(aEl);
                        ulEl.appendChild(liEl);
                    }

                    //khi trang hiện tại > 1 thì hiển thị nút back
                    //s += `<li><a href="" >‹<a>`;
                    var liEl = document.createElement("li");
                    liEl.onclick = (function (pageSelected) {
                        return function () {
                            options.selectPageCallback(pageSelected);

                            updateCurrentPage(pageSelected);

                            render();
                        }
                    })(options.currentPage - 1);

                    var aEl = document.createElement("a");
                    aEl.style.cursor = 'pointer';
                    aEl.innerHTML = '‹';
                    liEl.appendChild(aEl);

                    ulEl.appendChild(liEl);
                }
                
                //hiển thị số trang trên phân trang
                var displayFromPage = options.currentPage > 1 ? (options.currentPage - 1) : 1;
                var displayToPage = displayFromPage + 4;

                var countLoop = 1;
                for (var page = displayFromPage; page <= totalPages; page++) {
                    if (countLoop > options.pageSizeToDisplay) {
                        break;
                    }

                    createLiOfPage();

                    countLoop++;
                }

                //khi trang đang hiển thị cuối cùng mà nhỏ hơn totalPages thì hiển thị nút next
                if ((displayFromPage + countLoop) < totalPages) {
                    createLiToNextPage();

                    createLiMoveToEndPage();
                }
            }

            selector.html(ulEl);

            function render() {
                //console.log('render');
            }

            function createLiOfPage() {
                var liEl = document.createElement("li");
                liEl.setAttribute('data-page', page);
                if (page == options.currentPage) {
                    liEl.classList.add(options.customClass.currentPage);
                }

                liEl.onclick = (function (pageSelected) {
                    return function () {
                        options.selectPageCallback(pageSelected);

                        updateCurrentPage(pageSelected);

                        render();
                    }
                })(page);

                var aEl = document.createElement("a");
                aEl.style.cursor = 'pointer';
                aEl.innerHTML = page;
                liEl.appendChild(aEl);

                ulEl.appendChild(liEl);
            }

            function createLiMoveToEndPage() {
                var liEl = document.createElement("li");
                liEl.setAttribute('data-page', page);
                if (page == options.currentPage) {
                    liEl.classList.add(options.customClass.currentPage);
                }

                liEl.onclick = (function (pageSelected) {
                    return function () {
                        options.selectPageCallback(pageSelected);

                        updateCurrentPage(pageSelected);
                        render();
                    }
                })(totalPages);

                var aEl = document.createElement("a");
                aEl.style.cursor = 'pointer';
                aEl.innerHTML = '»';
                liEl.appendChild(aEl);

                ulEl.appendChild(liEl);
            }

            function createLiToNextPage() {
                var liEl = document.createElement("li");
                liEl.setAttribute('data-page', page);
                if (page == options.currentPage) {
                    liEl.classList.add(options.customClass.currentPage);
                }

                liEl.onclick = (function (pageSelected) {
                    return function () {
                        options.selectPageCallback(pageSelected);

                        updateCurrentPage(pageSelected);
                        render();
                    }
                })(options.currentPage + 1);

                var aEl = document.createElement("a");
                aEl.style.cursor = 'pointer';
                aEl.innerHTML = '›';
                liEl.appendChild(aEl);

                ulEl.appendChild(liEl);
            }

            function updateCurrentPage(currentPage) {
                options.currentPage = currentPage;
                selector.attr('data-currentPage', currentPage);
            }

            function getAllInfo() {
                return {
                    currentPage: selector.attr('data-currentPage')
                }
            }

            return {
                render: render
            }
        });
    }
})(jQuery);