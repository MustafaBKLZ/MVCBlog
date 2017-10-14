using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class BaseEntity
    {
        // yorum satırlarını silme

        public int ID { get; set; } 
        // primary key ve 1,1 olarak database e oto ekleniyor.

        public int Kaydeden { get; set; }

        #region kayıt_tarihi
        private DateTime _addDate = DateTime.Now;
        public DateTime KayitTarihi
        {
            get { return _addDate; }
            set { _addDate = value; }
        }
        #endregion
        // default olarak db ye şuanki tarih eklenecek. ayrıca insert etmemize gerek kalmayacak

        #region degiştiren
        private int? _DegistirenUser = -1;
        public int? Degistiren
        {
            get { return _DegistirenUser; }
            set { _DegistirenUser = value; }
        }
        #endregion
        // null olmaması için oto -1 kayıt ekledik.

        #region degiştirme tarihi
        private DateTime? _UpdateDate = new DateTime(1900, 01, 01);
        public DateTime? Degistirme_Tarihi
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }
        // private DateTime? _UpdateDate = new DateTime(1900, 01, 01);
        // public DateTime? Degistirme_Tarihi -- soru işareti ? boş geçilebilir olarak ayarlar.
        #endregion
        // null olmaması için oto eski kayıt ekledik.

        #region aktif
        private bool _AktifTrue = true;
        public bool Aktif
        {
            get { return _AktifTrue; }
            set { _AktifTrue = value; }
        }
        #endregion
        // otomatik olarak true ekledik.
    }
}