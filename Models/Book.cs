using System;

namespace BookManger.Models
{
    /// <summary>
    /// class lưu trữ thông tin về sách
    /// </summary>
    public class Book
    {
        private int _id = 1;
        private string authors = "Unknow authors";
        private string title = "A new book";
        private string publisher = "Unknow publisher";
        private int year = 2020;
        private int edition = 1;
        private string file = "";
        /// <summary>
        /// primary key
        /// </summary>
        public int Id 
        { 
            get { return _id; } 
            set { if (value >= 1) _id = value; } 
        }
        /// <summary>
        /// Nhóm tác giả sách
        /// </summary>
        public string Authors 
        { 
            get { return authors; } 
            set { if(!String.IsNullOrEmpty(value)) authors = value; } // không nhận giá trị null
        }
        /// <summary>
        /// Tên của cuốn sách
        /// </summary>
        public string Title 
        { 
            get { return title; } 
            set { if (!String.IsNullOrEmpty(value)) title = value; } // không nhận giá trị null
        }
        /// <summary>
        ///  Nhà xuất bản sách
        /// </summary>
        public string Publisher 
        {
            get { return publisher; }
            set { if (!String.IsNullOrEmpty(value)) publisher = value;}  // không nhận giá trị null
        }
        /// <summary>
        /// Năm xuất bản sách, từ 1950 đến năm hiện tại
        /// </summary>
        public int Year 
        {
            get { return year; } 
            set { if (value >= 1950) year = value; }
        }
        /// <summary>
        /// Lần tái bản sách, từ 1 trở đi
        /// </summary>
        public int Edition 
        { 
            get { return edition; }
            
            set { if (value >= 1) edition = value;}
          
        }
        /// <summary>
        /// Mã tiêu chuẩn sách quốc tế isbn
        /// </summary>
        public string ISBN { get; set; } = "";
        /// <summary>
        /// Từ khóa mô tả nội dung, thể loại
        /// </summary>
        public string Tags {get; set; } = "";
        /// <summary>
        /// Mô tả tóm tắt cuốn sách
        /// </summary>
        public string Description { get; set; } = "A new book";
        /// <summary>
        ///  Đường dẫn file sách
        /// </summary>
        public string File 
        { 
            get { return file; } 
            set { if (System.IO.File.Exists(value)) file = value; }
        }
        /// <summary>
        /// Đánh dấu đang đọc
        /// </summary>
        public bool Reading { get; set; } = false;
        /// <summary>
        /// Đánh giá sách, từ 1 đến 5.
        /// </summary>
        public int Rating { get; set;} = 1;
        /// <summary>
        /// return tên file sách
        /// </summary>
        public string FileName
        {
            get { return System.IO.Path.GetFileName(file); }
        }
    }
}