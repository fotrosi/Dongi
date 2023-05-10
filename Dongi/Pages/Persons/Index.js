$(function () {
    var l = abp.localization.getResource('Dongi');
    var createModal = new abp.ModalManager(abp.appPath + 'Persons/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Persons/EditModal');

    var dataTable = $('#PersonsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(dongi.services.person.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('PersonDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                            dongi.services.person
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewPersonButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });


});
