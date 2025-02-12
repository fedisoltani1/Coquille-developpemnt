//Recherche rapide dans un tableau
function rechercheFn(tableId, inputtext = 'rechercheRapide') {
    let table = document.getElementById(tableId);
    let filterValue = document.getElementById(inputtext).value.toUpperCase();
    let tr = table.getElementsByTagName('tr');
    for (let i = 1; i < tr.length; i++) {
        let td = tr[i].getElementsByTagName('td');
        let rowContainsFilterValue = false;
        for (let j = 0; j < td.length; j++) {
            if (td[j]) {
                if (td[j].textContent.toUpperCase().indexOf(filterValue) > -1) {
                    rowContainsFilterValue = true;
                    break;
                }
            }
        }
        if (rowContainsFilterValue) {
            tr[i].style.display = '';
        } else {
            tr[i].style.display = 'none';
        }
    }
}

//Table data to excel export
function exportTableToExcel(tableId, fileName) {
    let table = document.getElementById(tableId);
    let sheet = XLSX.utils.table_to_sheet(table);
    let wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, sheet, "Données");
    let wbout = XLSX.write(wb, { bookType: 'xlsx', type: 'binary' });

    function s2ab(s) {
        var buf = new ArrayBuffer(s.length);
        var view = new Uint8Array(buf);
        for (var i = 0; i < s.length; i++) view[i] = s.charCodeAt(i) & 0xFF;
        return buf;
    }

    let blob = new Blob([s2ab(wbout)], { type: 'application/octet-stream' });
    let url = URL.createObjectURL(blob);

    let a = document.createElement("a");
    a.href = url;
    a.download = fileName +".xlsx";
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
}