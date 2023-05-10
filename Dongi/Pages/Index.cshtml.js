(function(){
    var l = abp.localization.getResource('Dongi');

    var dataTable = $('#CheckoutTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: false,
            order: [],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(dongi.services.txManager.checkout),
            columnDefs: [                
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('CheckoutAmount'),
                    data: "checkoutAmount"
                }
            ]
        })
    );
})();
