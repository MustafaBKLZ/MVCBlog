


//database ve html den silme metodu
function Delete(url, id) { // parametre olarak id alıyor
    $.ajax(
        {
            url: url + id, // kategoriControllerdeki dilme metoduna erişiyor
            data: id, // data olarak id bilgisi gönderiliyor
            type: "POST", // işlem tipi
            success: function (result) { // işlem başarılı ise olacakları yazıyoruz.
                $("#a_" + id).fadeOut(); // DB den sildik ancak HTML olarakda silmek için ilgili satırı kaldırıyoruz.
            }
        }
    )
}