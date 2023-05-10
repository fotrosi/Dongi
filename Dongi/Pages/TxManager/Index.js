$(function () {
    var l = abp.localization.getResource('Dongi');
    var createModal = new abp.ModalManager(abp.appPath + 'TxManager/CreateModal');
    var detailModal = new abp.ModalManager(abp.appPath + 'TxManager/DetailModal');

    var dataTable = $('#TxsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[2, "desc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(dongi.services.txManager.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Details'),
                                    action: function (data) {
                                        detailModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'TxDeletionConfirmationMessage',
                                            data.record.description
                                        );
                                    },
                                    action: function (data) {
                                            dongi.services.txManager
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Description'),
                    data: "description"
                },
                {
                    title: l('Date'),
                    data: "date",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('TotalAmount'),
                    data: "totalAmount"
                },
                {
                    title: l('TotalQuota'),
                    data: "totalQuota"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    detailModal.onResult(function () {
        //dataTable.ajax.reload();
    });

    $('#NewTxButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
