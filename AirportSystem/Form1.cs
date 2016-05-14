using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportSystem
{
    public partial class Form1 : Form
    {
        DataLinqDataContext db = new DataLinqDataContext();
        public Form1()
        {
            InitializeComponent();
            dtp_CreatedDateOfLane.CustomFormat = "yyyy-MM-dd";
            dtp_CreatedDateOfPack.CustomFormat = "yyyy-MM-dd";
            dtp_CreatedDateOfWaiting.CustomFormat = "yyyy-MM-dd";
            dtp_DateSchedule.ShowUpDown = true;
            dtp_DateSchedule.Text = DateTime.Now.ToString();
            dtp_DateSchedule.CustomFormat = "yyyy-MM-dd";
            TakeConditions();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TakeConditions();
            
        }
        private void TakeConditions()
        {
            LoadGridViewLane();
            TakeConditionLane();
            LoadGridViewFlight();
            TakeConditionFlight();
            LoadGridViewPack();
            TakeConditionPack();
            LoadGridViewWaiting();
            TakeConditionWaiting();
            TakeConditionBranch();
            LoadGridViewBranch();
            TakeConditionSchedule();
            LoadGridViewSchedule();
            LoadGridViewComeToBranch();
            LoadGridViewLanding();
            LoadGridViewWayoff();
        }
        public void TakeConditionLane()
        {
            var tinhTrangDuongBang = from tinhtrang in db.TinhTrangs

                                     select new
                                     {
                                         ID = tinhtrang.IDTinhTrang,
                                         Ten = tinhtrang.TenTinhTrang,

                                     };
            cmb_StatusOfLane.DataSource = tinhTrangDuongBang;
            cmb_StatusOfLane.ValueMember = "ID";
            cmb_StatusOfLane.DisplayMember = "Ten";
            List<string> listSearchLane = new List<string>();
            listSearchLane.Add("Ten Duong Bang");
            listSearchLane.Add("Ngay Khoi Tao");
            listSearchLane.Add("Tinh Trang");
            cmb_SearchLane.DataSource = listSearchLane;
        }
        public void TakeConditionPack()
        {
            var tinhTrangBaiDo = from tinhtrang in db.TinhTrangs

                                     select new
                                     {
                                         ID = tinhtrang.IDTinhTrang,
                                         Ten = tinhtrang.TenTinhTrang,

                                     };
            cmb_StatusOfPack.DataSource = tinhTrangBaiDo;
            cmb_StatusOfPack.ValueMember = "ID";
            cmb_StatusOfPack.DisplayMember = "Ten";
            List<string> listSearchPack = new List<string>();
            listSearchPack.Add("Ten Bai Do");
            listSearchPack.Add("Ngay Khoi Tao");
            listSearchPack.Add("Tinh Trang");
            cmb_SearchPack.DataSource = listSearchPack;
        }
        public void TakeConditionFlight()
        {
            var tinhTrangMayBay = from tinhtrang in db.TinhTrangs

                                  select new
                                  {
                                      ID = tinhtrang.IDTinhTrang,
                                      Ten = tinhtrang.TenTinhTrang,
                                  };
            cmb_StatusOfFlight.DataSource = tinhTrangMayBay;
            cmb_StatusOfFlight.ValueMember = "ID";
            cmb_StatusOfFlight.DisplayMember = "Ten";
            var hangMayBay = from hang in db.HangMayBays

                             select new
                             {
                                 ID = hang.IDHangMayBay,
                                 Ten = hang.TenHangMayBay
                             };
            cmb_CompanyOfFlight.DataSource = hangMayBay;
            cmb_CompanyOfFlight.ValueMember = "ID";
            cmb_CompanyOfFlight.DisplayMember = "Ten";
            List<string> listSearchFlight = new List<string>();
            listSearchFlight.Add("Ten May Bay");
            listSearchFlight.Add("Hang May Bay");
            listSearchFlight.Add("Tinh Trang");
            cmb_SearchFlight.DataSource = listSearchFlight;

            List<String> listPosition = new List<string>();
            listPosition.Add("True");
            listPosition.Add("False");
            cmb_PositionOfFlight.DataSource = listPosition;
        }
        public void TakeConditionWaiting()
        {
            var tinhTrangSanhCho = from tinhtrang in db.TinhTrangs

                                     select new
                                     {
                                         ID = tinhtrang.IDTinhTrang,
                                         Ten = tinhtrang.TenTinhTrang,

                                     };
            cmb_StatusOfWaiting.DataSource = tinhTrangSanhCho;
            cmb_StatusOfWaiting.ValueMember = "ID";
            cmb_StatusOfWaiting.DisplayMember = "Ten";
            List<string> listSearchWaiting = new List<string>();
            listSearchWaiting.Add("Ten Sanh Cho");
            listSearchWaiting.Add("Ngay Khoi Tao");
            listSearchWaiting.Add("Tinh Trang");
            cmb_SearchWaiting.DataSource = listSearchWaiting;
        }
        public void TakeConditionBranch()
        {
            var tinhTrangDuongLan = from tinhtrang in db.TinhTrangs

                                   select new
                                   {
                                       ID = tinhtrang.IDTinhTrang,
                                       Ten = tinhtrang.TenTinhTrang,

                                   };
            cmb_StatusOfBranch.DataSource = tinhTrangDuongLan;
            cmb_StatusOfBranch.ValueMember = "ID";
            cmb_StatusOfBranch.DisplayMember = "Ten";
            List<string> listSearchBranch = new List<string>();
            listSearchBranch.Add("Ten Duong Lan");
            listSearchBranch.Add("Ngay Khoi Tao");
            listSearchBranch.Add("Tinh Trang");
            listSearchBranch.Add("Thuoc Duong Bang");
            cmb_SearchBranch.DataSource = listSearchBranch;

            var listDuongBang = from duongbang in db.DuongBays

                                    select new
                                    {
                                        ID = duongbang.IDDuongBay,
                                        Ten = duongbang.TenDuongBay

                                    };
            cmb_BranchBelongTo.DataSource = listDuongBang;
            cmb_BranchBelongTo.ValueMember = "ID";
            cmb_BranchBelongTo.DisplayMember = "Ten";

        }
        public void TakeConditionSchedule()
        {
            var listmaybay = from maybay in db.MayBays

                                    select new
                                    {
                                        ID = maybay.IDMayBay,
                                        Ten = maybay.TenMayBay,

                                    };
            cmb_FlightOfSchedule.DataSource = listmaybay;
            cmb_FlightOfSchedule.ValueMember = "ID";
            cmb_FlightOfSchedule.DisplayMember = "Ten";
            List<string> listSearchSchedule = new List<string>();
            listSearchSchedule.Add("Ten Lich Trinh");
            listSearchSchedule.Add("Ten May Bay");
            cmb_SearchSchedule.DataSource = listSearchSchedule;

            var listhuongbay = from huongbay in db.HuongBays

                             select new
                             {
                                 ID = huongbay.IDHuongBay,
                                 Ten = huongbay.TenHuongBay

                             };
            cmb_DirectionSchedule.DataSource = listhuongbay;
            cmb_DirectionSchedule.ValueMember = "ID";
            cmb_DirectionSchedule.DisplayMember = "Ten";

            List<string> listComeOrLeave = new List<string>();
            listComeOrLeave.Add("Bay Den");
            listComeOrLeave.Add("Bay Di");
            cmb_ComeOrLeaveSchedule.DataSource = listComeOrLeave;
            

        }
        public void LoadGridViewWaiting()
        {
            var listWaiting = from waiting in db.SanhChos
                           join tt in db.TinhTrangs
                           on waiting.IDTinhTrang equals tt.IDTinhTrang
                           select new
                           {
                               ID = waiting.IDSanhCho,
                               Ten = waiting.TenSanhCho,
                               NgayKhoiTao = waiting.NgayKhoiTao,
                               TinhTrang = tt.TenTinhTrang
                           };
            dgv_Waiting.DataSource = listWaiting;
            txt_IDWaiting.DataBindings.Clear();
            txt_IDWaiting.DataBindings.Add("Text", listWaiting, "ID");
            txt_NameOfWaiting.DataBindings.Clear();
            txt_NameOfWaiting.DataBindings.Add("Text", listWaiting, "Ten");
            dtp_CreatedDateOfWaiting.DataBindings.Clear();
            dtp_CreatedDateOfWaiting.DataBindings.Add("Text", listWaiting, "NgayKhoiTao");
            cmb_StatusOfWaiting.DataBindings.Clear();
            cmb_StatusOfWaiting.DataBindings.Add("Text", listWaiting, "TinhTrang");
        }
        public void LoadGridViewBranch()
        {
            var listBranch = from branch in db.DuongLans
                             join tt in db.TinhTrangs
                             on branch.IDTinhTrang equals tt.IDTinhTrang
                             join lane in db.DuongBays
                             on branch.IDDuongBay equals lane.IDDuongBay
                             select new
                             {
                                 ID = branch.IDDuongLan,
                                 Ten = branch.TenDuongLan,
                                 NgayKhoiTao = branch.NgayKhoiTao,
                                 TinhTrang = tt.TenTinhTrang,
                                 Duongbay = lane.TenDuongBay
                             };
            dgv_Branch.DataSource = listBranch;
            txt_IDBranch.DataBindings.Clear();
            txt_IDBranch.DataBindings.Add("Text", listBranch, "ID");
            txt_NameOfBranch.DataBindings.Clear();
            txt_NameOfBranch.DataBindings.Add("Text", listBranch, "Ten");
            cmb_StatusOfBranch.DataBindings.Clear();
            cmb_StatusOfBranch.DataBindings.Add("Text", listBranch, "TinhTrang");
            cmb_BranchBelongTo.DataBindings.Clear();
            cmb_BranchBelongTo.DataBindings.Add("Text", listBranch, "Duongbay");
            dtp_CreatedDateOfBranch.DataBindings.Clear();
            dtp_CreatedDateOfBranch.DataBindings.Add("Text", listBranch, "NgayKhoiTao");
        }
        public void LoadGridViewPack()
        {
            var listPack = from pack in db.BaiDos
                           join tt in db.TinhTrangs
                           on pack.IDTinhTrang equals tt.IDTinhTrang
                           select new
                           {
                               ID = pack.IDBaiDo,
                               Ten = pack.TenBaiDo,
                               NgayKhoiTao = pack.NgayKhoiTao,
                               TinhTrang = tt.TenTinhTrang
                           };
            dgv_Pack.DataSource = listPack;
            txt_IDPack.DataBindings.Clear();
            txt_IDPack.DataBindings.Add("Text", listPack, "ID");
            txt_NameOfPack.DataBindings.Clear();
            txt_NameOfPack.DataBindings.Add("Text", listPack, "Ten");
            dtp_CreatedDateOfPack.DataBindings.Clear();
            dtp_CreatedDateOfPack.DataBindings.Add("Text", listPack, "NgayKhoiTao");
            cmb_StatusOfPack.DataBindings.Clear();
            cmb_StatusOfPack.DataBindings.Add("Text", listPack, "TinhTrang");
        }
        public void LoadGridViewLane()
        {
            var listLane = from dbay in db.DuongBays
                           join tt in db.TinhTrangs
                           on dbay.IDTinhTrang equals tt.IDTinhTrang
                           select new
                           {
                               ID=dbay.IDDuongBay,
                               Ten=dbay.TenDuongBay,
                               NgayKhoiTao=dbay.NgayKhoiTao,
                               TinhTrang=tt.TenTinhTrang
                           };
            dgv_Lane.DataSource = listLane;
            txt_IDLane.DataBindings.Clear();
            txt_IDLane.DataBindings.Add("Text", listLane, "ID");
            txt_NameOfLane.DataBindings.Clear();
            txt_NameOfLane.DataBindings.Add("Text", listLane, "Ten");
            dtp_CreatedDateOfLane.DataBindings.Clear();
            dtp_CreatedDateOfLane.DataBindings.Add("Text", listLane, "NgayKhoiTao");
            cmb_StatusOfLane.DataBindings.Clear();
            cmb_StatusOfLane.DataBindings.Add("Text", listLane, "TinhTrang");
        }
       
        public void LoadGridViewFlight()
        {
            var listFlight = from flight in db.MayBays
                           join tt in db.TinhTrangs
                           on flight.IDTinhTrang equals tt.IDTinhTrang
                           join com in db.HangMayBays
                           on flight.IDHangMayBay equals com.IDHangMayBay
                           select new
                           {
                               ID = flight.IDMayBay,
                               Ten = flight.TenMayBay,
                               Vitri=flight.DangOSanBay,
                               TinhTrang=tt.TenTinhTrang,
                               Hang=com.TenHangMayBay
                           };
            dgv_Flight.DataSource = listFlight;
            txt_IDFlight.DataBindings.Clear();
            txt_IDFlight.DataBindings.Add("Text", listFlight, "ID");
            txt_NameOfFlight.DataBindings.Clear();
            txt_NameOfFlight.DataBindings.Add("Text", listFlight, "Ten");
            cmb_StatusOfFlight.DataBindings.Clear();
            cmb_StatusOfFlight.DataBindings.Add("Text", listFlight, "TinhTrang");
            cmb_PositionOfFlight.DataBindings.Clear();
            cmb_PositionOfFlight.DataBindings.Add("Text", listFlight, "Vitri");
            cmb_CompanyOfFlight.DataBindings.Clear();
            cmb_CompanyOfFlight.DataBindings.Add("Text", listFlight, "Hang");
        }
        public void LoadGridViewSchedule()
        {
            var listSchedule = from lichtrinh in db.LichTrinhs
                             join maybay in db.MayBays
                             on lichtrinh.IDMayBay equals maybay.IDMayBay
                             join huong in db.HuongBays
                             on lichtrinh.IDHuongBay equals huong.IDHuongBay
                             select new
                             {
                                 ID = lichtrinh.IDLichTrinh,
                                 Ten = lichtrinh.TenLichTrinh,
                                 ThoiGianBatDau= lichtrinh.ThoiGianBatDau,
                                 NgayBatDau=lichtrinh.NgayBatDau,
                                 Huong=huong.TenHuongBay,
                                 DenHayDi=lichtrinh.BayDen,
                                 TenMayBay=maybay.TenMayBay
                                 
                             };
            dgv_Schedule.DataSource = listSchedule;
            dgv_Schedule.DataBindings.Clear();
            txt_IDSchedule.DataBindings.Clear();
            txt_IDSchedule.DataBindings.Add("Text", listSchedule, "ID");
            txt_NameOfSchedule.DataBindings.Clear();
            txt_NameOfSchedule.DataBindings.Add("Text", listSchedule, "Ten");
            
            dtp_DateSchedule.DataBindings.Clear();
            dtp_DateSchedule.DataBindings.Add("Text", listSchedule, "NgayBatDau");
            cmb_FlightOfSchedule.DataBindings.Clear();
            cmb_FlightOfSchedule.DataBindings.Add("Text", listSchedule, "TenMayBay");
            cmb_DirectionSchedule.DataBindings.Clear();
            cmb_DirectionSchedule.DataBindings.Add("Text", listSchedule, "Huong");
            cmb_ComeOrLeaveSchedule.DataBindings.Clear();
            cmb_ComeOrLeaveSchedule.DataBindings.Add("Text", listSchedule, "DenHayDi");

        }
        public void LoadGridViewPickUpPassenger()
        {
            var listPickUp = from donkhach in db.DonKhaches
                               join maybay in db.MayBays
                               on donkhach.IDMayBay equals maybay.IDMayBay
                               join sanhcho in db.SanhChos
                               on donkhach.IDSanhCho equals sanhcho.IDSanhCho
                               select new
                               {
                                   ID = donkhach.IDDonKhach,
                                   TenMayBay=maybay.TenMayBay,
                                   TenSanhCho=sanhcho.TenSanhCho,
                                   ThoiGianVaoSanhCho=donkhach.ThoiGianVaoSanhCho,
                                   NgayVaoSanhCho=donkhach.NgayVaoSanhCho,
                                   ThoiGianRaSanhCho = donkhach.ThoiGianRaSanhCho,
                                   NgayRaDuongLan=donkhach.NgayRaSanhCho
                                   

                               };
            dgv_PickUpPassenger.DataSource = listPickUp;
        }
        public void LoadGridViewComeToBranch()
        {
            var listComeToBranch = from vaoduonglan in db.VaoDuongLans
                             join maybay in db.MayBays
                             on vaoduonglan.IDMayBay equals maybay.IDMayBay
                             join duonglan in db.DuongLans
                             on vaoduonglan.IDDuongLan equals duonglan.IDDuongLan
                             select new
                             {
                                 ID = vaoduonglan.IDVaoDuongLan,
                                 TenMayBay = maybay.TenMayBay,
                                 TenDuongLan = duonglan.TenDuongLan,
                                 ThoiGianVaoDuongLan = vaoduonglan.ThoiGianVaoDuongLan,
                                 NgayVaoDuongLan = vaoduonglan.NgayVaoDuongLan,
                                 ThoiGianRaDuongLan = vaoduonglan.ThoiGianRaDuongLan,
                                 NgayRaDuongLan=vaoduonglan.NgayVaoDuongLan



                             };
            dgv_ComeToBranch.DataSource = listComeToBranch;
        }
        public void LoadGridViewLanding()
        {
            var listLanding = from hacanh in db.HaCanhs
                                   join maybay in db.MayBays
                                   on hacanh.IDMayBay equals maybay.IDMayBay
                                   join duongbang in db.DuongBays
                                   on hacanh.IDDuongBay equals duongbang.IDDuongBay
                                   select new
                                   {
                                       ID = hacanh.IDHaCanh,
                                       TenMayBay = maybay.TenMayBay,
                                       TenDuongBang = duongbang.TenDuongBay,
                                       ThoiGianHaCanh = hacanh.GioiGianVaoDuongBang,
                                       NgayHaCanh= hacanh.NgayVaoDuongBang,
                                       ThoiGianRaDuongBang = hacanh.ThoiGianRaDuongBang,
                                       NgayRaDuongBang = hacanh.NgayVaoDuongBang



                                   };
            dgv_WayOf.DataSource = listLanding;
        }
        public void LoadGridViewWayoff()
        {
            var listWayOff = from cachcach in db.CachCanhs
                              join maybay in db.MayBays
                              on cachcach.IDMayBay equals maybay.IDMayBay
                              join duongbang in db.DuongBays
                              on cachcach.IDDuongBay equals duongbang.IDDuongBay
                              select new
                              {
                                  ID = cachcach.IDCachCanh,
                                  TenMayBay = maybay.TenMayBay,
                                  TenDuongBang = duongbang.TenDuongBay,
                                  ThoiGianVaoDuongBang = cachcach.ThoiGianVaoDuongBang,
                                  NgayVaoDuongBang = cachcach.NgayVaoDuongBang,
                                  ThoiGianCachCanh = cachcach.ThoiGianRaDuongBang,
                                  NgayCachCanh = cachcach.NgayVaoDuongBang



                              };
            dgv_WayOf.DataSource = listWayOff;
        }
        public void LoadGridViewLeavePassenger()
        {
            var listLeave = from trakhach in db.TraKhaches
                             join maybay in db.MayBays
                             on trakhach.IDMayBay equals maybay.IDMayBay
                             join sanhcho in db.SanhChos
                             on trakhach.IDSanhCho equals sanhcho.IDSanhCho
                             select new
                             {
                                 ID = trakhach.IDTraKhach,
                                 TenMayBay = maybay.TenMayBay,
                                 TenSanhCho = sanhcho.TenSanhCho,
                                 ThoiGianVaoSanhCho = trakhach.ThoiGianVaoSanhCho,
                                 NgayVaoSanhCho = trakhach.NgayVaoSanhCho,
                                 ThoiGianRaSanhCho = trakhach.ThoiGianRaSanhCho,
                                 NgayRaDuongLan = trakhach.NgayRaSanhCho


                             };
            dgv_LeavePassenger.DataSource = listLeave;
        }
        private void btn_NewLane_Click(object sender, EventArgs e)
        {
            txt_NameOfLane.Text = "";
            dtp_CreatedDateOfLane.Text = DateTime.Now.ToString();
            
        }

        private void btn_AddLane_Click(object sender, EventArgs e)
        {
            int idtinhtrang = (int)cmb_StatusOfLane.SelectedValue;
            DuongBay duongbay = new DuongBay();
            duongbay.TenDuongBay = txt_NameOfLane.Text;
            duongbay.NgayKhoiTao = dtp_CreatedDateOfLane.Value;
            duongbay.IDTinhTrang = idtinhtrang;
            db.DuongBays.InsertOnSubmit(duongbay);
            db.SubmitChanges();
            LoadGridViewLane();
            
        }

        private void btn_DeleteLane_Click(object sender, EventArgs e)
        {
            var deleteLane = from duongbay in db.DuongBays
                             where duongbay.TenDuongBay == txt_NameOfLane.Text
                             select duongbay;
            db.DuongBays.DeleteAllOnSubmit(deleteLane);
            db.SubmitChanges();
            LoadGridViewLane();     
        }

        private void btn_UpdateLane_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txt_IDLane.Text);
            int idtinhtrang = (int)cmb_StatusOfLane.SelectedValue;
            DuongBay duongbayupdate = (from duongbay in db.DuongBays where duongbay.IDDuongBay == id select duongbay).SingleOrDefault();
            duongbayupdate.TenDuongBay = txt_NameOfLane.Text;
            duongbayupdate.NgayKhoiTao = dtp_CreatedDateOfLane.Value;
            duongbayupdate.IDTinhTrang = idtinhtrang;
            db.SubmitChanges();
            LoadGridViewLane();
        }


        private void btn_SearchLane_Click(object sender, EventArgs e)
        {
            
            if("Ten Duong Bang".Equals(cmb_SearchLane.Text))
                {
                var listLane = from dbay in db.DuongBays
                               join tt in db.TinhTrangs
                               on dbay.IDTinhTrang equals tt.IDTinhTrang
                               where dbay.TenDuongBay==txt_SearchLane.Text
                               select new
                               {
                                   ID = dbay.IDDuongBay,
                                   Ten = dbay.TenDuongBay,
                                   NgayKhoiTao = dbay.NgayKhoiTao,
                                   TinhTrang = tt.TenTinhTrang
                               };
                dgv_Lane.DataSource = listLane;
            }
            else if("Tinh Trang".Equals(cmb_SearchLane.Text))
            {
                
                var listLane = from dbay in db.DuongBays
                           join tt in db.TinhTrangs
                           on dbay.IDTinhTrang equals tt.IDTinhTrang
                           where tt.TenTinhTrang==txt_SearchLane.Text
                           select new
                           {
                               dbay.IDDuongBay,
                               dbay.TenDuongBay,
                               dbay.NgayKhoiTao,
                               tt.TenTinhTrang
                           };
                dgv_Lane.DataSource = listLane;
            }
            else
            {
                DateTime date = Convert.ToDateTime(txt_SearchLane.Text);
                var listLane = from dbay in db.DuongBays
                               join tt in db.TinhTrangs
                               on dbay.IDTinhTrang equals tt.IDTinhTrang
                               where dbay.NgayKhoiTao == date
                               select new
                               {
                                   dbay.IDDuongBay,
                                   dbay.TenDuongBay,
                                   dbay.NgayKhoiTao,
                                   tt.TenTinhTrang
                               };
                dgv_Lane.DataSource = listLane;
            }


        }

        private void btn_NewFlight_Click(object sender, EventArgs e)
        {
            txt_NameOfFlight.Text = "";
            txt_SearchFlight.Text = "";

        }

        private void btn_AddFlight_Click(object sender, EventArgs e)
        {
            MayBay maybay = new MayBay();
            maybay.TenMayBay = txt_NameOfFlight.Text;
            maybay.DangOSanBay = Convert.ToBoolean(cmb_PositionOfFlight.Text);
            maybay.IDTinhTrang = (int)cmb_StatusOfFlight.SelectedValue;
            maybay.IDHangMayBay = (int)cmb_CompanyOfFlight.SelectedValue;
            db.MayBays.InsertOnSubmit(maybay);
            db.SubmitChanges();
            LoadGridViewFlight();
        }

        private void btn_UpdateFlight_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txt_IDFlight.Text);
            int idtinhtrang = (int)cmb_StatusOfFlight.SelectedValue;
            int idhangmaybay = (int)cmb_CompanyOfFlight.SelectedValue;
            Boolean vitri = Convert.ToBoolean(cmb_PositionOfFlight.Text);
            MayBay maybayUpdate = (from maybay in db.MayBays where maybay.IDMayBay == id select maybay).SingleOrDefault();
            maybayUpdate.TenMayBay = txt_NameOfFlight.Text;
            maybayUpdate.DangOSanBay = vitri;
            maybayUpdate.IDHangMayBay = idhangmaybay;
            maybayUpdate.IDTinhTrang = idtinhtrang;
            db.SubmitChanges();
            LoadGridViewFlight();
        }

        private void btn_DeleteFlight_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txt_IDFlight.Text);
                             
            var deleteFlight = from maybay in db.MayBays
                             where maybay.IDMayBay == id
                             select maybay;
            db.MayBays.DeleteAllOnSubmit(deleteFlight);
            db.SubmitChanges();
            LoadGridViewFlight();
        }

        private void btn_SearchFlight_Click(object sender, EventArgs e)
        {
            if ("Ten May Bay".Equals(cmb_SearchFlight.Text))
            {
                var listFlight = from maybay in db.MayBays
                                 join tt in db.TinhTrangs
                                 on maybay.IDTinhTrang equals tt.IDTinhTrang
                                 join hang in db.HangMayBays
                                 on maybay.IDHangMayBay equals hang.IDHangMayBay
                                 where maybay.TenMayBay == txt_SearchFlight.Text
                                 select new
                                 {
                                     ID = maybay.IDMayBay,
                                     Ten = maybay.TenMayBay,
                                     Vitri = maybay.DangOSanBay,
                                     TinhTrang = tt.TenTinhTrang,
                                     Hang = hang.TenHangMayBay
                                 };
                dgv_Flight.DataSource = listFlight;
            }
            else if ("Hang May Bay".Equals(cmb_SearchFlight.Text))
            {
                
                var listFlight = from maybay in db.MayBays
                                 join tt in db.TinhTrangs
                                 on maybay.IDTinhTrang equals tt.IDTinhTrang
                                 join hang in db.HangMayBays
                                 on maybay.IDHangMayBay equals hang.IDHangMayBay
                                 where hang.TenHangMayBay == txt_SearchFlight.Text
                                 select new
                                 {
                                     ID = maybay.IDMayBay,
                                     Ten = maybay.TenMayBay,
                                     Vitri = maybay.DangOSanBay,
                                     TinhTrang = tt.TenTinhTrang,
                                     Hang = hang.TenHangMayBay
                                 };
                dgv_Flight.DataSource = listFlight;
            }
            else
            {

                var listflight = from maybay in db.MayBays
                                 join tt in db.TinhTrangs
                                 on maybay.IDTinhTrang equals tt.IDTinhTrang
                                 join hang in db.HangMayBays
                                 on maybay.IDHangMayBay equals hang.IDHangMayBay
                                 where tt.TenTinhTrang==txt_SearchFlight.Text
                                 select new
                                 {
                                     ID = maybay.IDMayBay,
                                     Ten = maybay.TenMayBay,
                                     Vitri = maybay.DangOSanBay,
                                     TinhTrang = tt.TenTinhTrang,
                                     Hang = hang.TenHangMayBay
                                 };
                dgv_Flight.DataSource = listflight;
            }

        }

        private void btn_NewWaiting_Click(object sender, EventArgs e)
        {
            txt_NameOfWaiting.Text = "";
            dtp_CreatedDateOfWaiting.Text = DateTime.Now.ToString();
        }

        private void btn_AddWaiting_Click(object sender, EventArgs e)
        {
            int idtinhtrang = (int)cmb_StatusOfWaiting.SelectedValue;
            SanhCho sanhcho = new SanhCho();
            sanhcho.TenSanhCho = txt_NameOfWaiting.Text;
            sanhcho.NgayKhoiTao = dtp_CreatedDateOfWaiting.Value;
            sanhcho.IDTinhTrang = idtinhtrang;
            db.SanhChos.InsertOnSubmit(sanhcho);
            db.SubmitChanges();
            LoadGridViewWaiting();
        }

        private void btn_UpdateWaiting_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txt_IDWaiting.Text);
            int idtinhtrang = (int)cmb_StatusOfWaiting.SelectedValue;
            SanhCho sanhchoUpdate = (from sanhcho in db.SanhChos where sanhcho.IDSanhCho == id select sanhcho).SingleOrDefault();
            sanhchoUpdate.TenSanhCho = txt_NameOfWaiting.Text;
            sanhchoUpdate.NgayKhoiTao = dtp_CreatedDateOfWaiting.Value;
            sanhchoUpdate.IDTinhTrang = idtinhtrang;
            db.SubmitChanges();
            LoadGridViewWaiting();
        }

        private void btn_DeleteWaiting_Click(object sender, EventArgs e)
        {
            var deleteWaiting = from sanhcho in db.SanhChos 
                             where sanhcho.TenSanhCho == txt_NameOfWaiting.Text
                             select sanhcho;
            db.SanhChos.DeleteAllOnSubmit(deleteWaiting);
            db.SubmitChanges();
            LoadGridViewWaiting();
        }

        private void btn_SearchWaiting_Click(object sender, EventArgs e)
        {
            if ("Ten Sanh Cho".Equals(cmb_SearchWaiting.Text))
            {
                var listWaiting = from sanhcho in db.SanhChos
                               join tt in db.TinhTrangs
                               on sanhcho.IDTinhTrang equals tt.IDTinhTrang
                               where sanhcho.TenSanhCho == txt_SearchWaiting.Text
                               select new
                               {
                                   ID = sanhcho.IDSanhCho,
                                   Ten = sanhcho.TenSanhCho,
                                   NgayKhoiTao = sanhcho.NgayKhoiTao,
                                   TinhTrang = tt.TenTinhTrang
                               };
                dgv_Waiting.DataSource = listWaiting;
            }
            else if ("Tinh Trang".Equals(cmb_SearchWaiting.Text))
            {

                var listWaiting = from sanhcho in db.SanhChos
                                  join tt in db.TinhTrangs
                                  on sanhcho.IDTinhTrang equals tt.IDTinhTrang
                                  where tt.TenTinhTrang == txt_SearchWaiting.Text
                                  select new
                                  {
                                      ID = sanhcho.IDSanhCho,
                                      Ten = sanhcho.TenSanhCho,
                                      NgayKhoiTao = sanhcho.NgayKhoiTao,
                                      TinhTrang = tt.TenTinhTrang
                                  };
                dgv_Waiting.DataSource = listWaiting;
            }
            else
            {
                DateTime date = Convert.ToDateTime(txt_SearchWaiting.Text);
                var listWaiting = from sanhcho in db.SanhChos
                                  join tt in db.TinhTrangs
                                  on sanhcho.IDTinhTrang equals tt.IDTinhTrang
                                  where sanhcho.NgayKhoiTao==date
                                  select new
                                  {
                                      ID = sanhcho.IDSanhCho,
                                      Ten = sanhcho.TenSanhCho,
                                      NgayKhoiTao = sanhcho.NgayKhoiTao,
                                      TinhTrang = tt.TenTinhTrang
                                  };
                dgv_Waiting.DataSource = listWaiting;
            }
        }

        private void btn_NewBranch_Click(object sender, EventArgs e)
        {
            txt_NameOfBranch.Text = "";
            txt_SearchBranch.Text = "";
            cmb_BranchBelongTo.SelectedValue = 1;
            cmb_StatusOfBranch.SelectedValue = 1;
            dtp_CreatedDateOfBranch.Text = DateTime.Now.ToString();

        }

        private void btn_AddBranch_Click(object sender, EventArgs e)
        {
            int idtinhtrang = (int)cmb_StatusOfBranch.SelectedValue;
            int idduongbang = (int)cmb_BranchBelongTo.SelectedValue;
            DuongLan duonglan = new DuongLan();
            duonglan.TenDuongLan = txt_NameOfBranch.Text;
            duonglan.NgayKhoiTao = dtp_CreatedDateOfBranch.Value;
            duonglan.IDTinhTrang = idtinhtrang;
            duonglan.IDDuongBay = idduongbang;
            db.DuongLans.InsertOnSubmit(duonglan);
            db.SubmitChanges();
            LoadGridViewBranch();
        }

        private void btn_DeleteBranch_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txt_IDBranch.Text);

            var deleteBranch = from duonglan in db.DuongLans
                               where duonglan.IDDuongLan == id
                               select duonglan;
            db.DuongLans.DeleteAllOnSubmit(deleteBranch);
            db.SubmitChanges();
            LoadGridViewBranch();
        }

        private void btn_UpdateBranch_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txt_IDBranch.Text);
            int idduongbay = (int)cmb_BranchBelongTo.SelectedValue;
            int idtinhtrang = (int)cmb_StatusOfBranch.SelectedValue;
            DuongLan duonglanUpdate = (from duonglan in db.DuongLans where duonglan.IDDuongLan == id select duonglan).SingleOrDefault();
            duonglanUpdate.TenDuongLan = txt_NameOfBranch.Text;
            duonglanUpdate.NgayKhoiTao = dtp_CreatedDateOfBranch.Value;
            duonglanUpdate.IDTinhTrang = idtinhtrang;
            duonglanUpdate.IDDuongBay = idduongbay;

            db.SubmitChanges();
            LoadGridViewBranch();
        }

        private void btn_SearchBranch_Click(object sender, EventArgs e)
        {
            if ("Ten Duong Lan".Equals(cmb_SearchBranch.Text))
            {
                var listBranch = from duonglan in db.DuongLans
                                  join tt in db.TinhTrangs
                                  on duonglan.IDTinhTrang equals tt.IDTinhTrang
                                  join duongbay in db.DuongBays
                                  on duonglan.IDDuongBay equals duongbay.IDDuongBay
                                  where duonglan.TenDuongLan == txt_SearchBranch.Text
                                  select new
                                  {
                                      ID = duonglan.IDDuongLan,
                                      Ten = duonglan.TenDuongLan,
                                      NgayKhoiTao = duonglan.NgayKhoiTao,
                                      TinhTrang = tt.TenTinhTrang,
                                      Duongbay = duongbay.TenDuongBay
                                  };
                dgv_Branch.DataSource = listBranch;
            }
            else if ("Tinh Trang".Equals(cmb_SearchBranch.Text))
            {

                var listBranch = from duonglan in db.DuongLans
                                 join tt in db.TinhTrangs
                                 on duonglan.IDTinhTrang equals tt.IDTinhTrang
                                 join duongbay in db.DuongBays
                                 on duonglan.IDDuongBay equals duongbay.IDDuongBay
                                 where tt.TenTinhTrang == txt_SearchBranch.Text
                                 select new
                                 {
                                     ID = duonglan.IDDuongLan,
                                     Ten = duonglan.TenDuongLan,
                                     NgayKhoiTao = duonglan.NgayKhoiTao,
                                     TinhTrang = tt.TenTinhTrang,
                                     Duongbay = duongbay.TenDuongBay
                                 };
                dgv_Branch.DataSource = listBranch;
            }
            else if("Ngay Khoi Tao".Equals(cmb_SearchBranch.Text))
            {
                DateTime date = Convert.ToDateTime(txt_SearchBranch.Text);
                var listBranch = from duonglan in db.DuongLans
                                 join tt in db.TinhTrangs
                                 on duonglan.IDTinhTrang equals tt.IDTinhTrang
                                 join duongbay in db.DuongBays
                                 on duonglan.IDDuongBay equals duongbay.IDDuongBay
                                 where duonglan.NgayKhoiTao == date
                                 select new
                                 {
                                     ID = duonglan.IDDuongLan,
                                     Ten = duonglan.TenDuongLan,
                                     NgayKhoiTao = duonglan.NgayKhoiTao,
                                     TinhTrang = tt.TenTinhTrang,
                                     Duongbay = duongbay.TenDuongBay
                                 };
                dgv_Branch.DataSource = listBranch;
            }
            else
            {
                var listBranch = from duonglan in db.DuongLans
                                 join tt in db.TinhTrangs
                                 on duonglan.IDTinhTrang equals tt.IDTinhTrang
                                 join duongbay in db.DuongBays
                                 on duonglan.IDDuongBay equals duongbay.IDDuongBay
                                 where duongbay.TenDuongBay == txt_SearchBranch.Text
                                 select new
                                 {
                                     ID = duonglan.IDDuongLan,
                                     Ten = duonglan.TenDuongLan,
                                     NgayKhoiTao = duonglan.NgayKhoiTao,
                                     TinhTrang = tt.TenTinhTrang,
                                     Duongbay = duongbay.TenDuongBay
                                 };
                dgv_Branch.DataSource = listBranch;
            }
        }

        private void btn_NewSchedule_Click(object sender, EventArgs e)
        {
            txt_NameOfSchedule.Text = "";
            cmb_FlightOfSchedule.SelectedValue = 1;
            //dtp_TimeOfSchedule.Text = DateTime.Now.TimeOfDay.ToString();
            dtp_DateSchedule.Text = DateTime.Now.ToString();
        }

        private void btn_AddSchedule_Click(object sender, EventArgs e)
        {
            int idmaybay = (int)cmb_FlightOfSchedule.SelectedValue;
            int idhuong = (int)cmb_DirectionSchedule.SelectedValue;
            string baydenhaydi = cmb_ComeOrLeaveSchedule.SelectedValue.ToString();
            LichTrinh lichtrinh = new LichTrinh();
            lichtrinh.TenLichTrinh = txt_NameOfSchedule.Text;
            lichtrinh.IDMayBay = idmaybay;
            lichtrinh.IDHuongBay = idhuong;
            dtp_TimeSchedule.DataBindings.Clear();
            lichtrinh.ThoiGianBatDau = dtp_TimeSchedule.Value.TimeOfDay;
            lichtrinh.NgayBatDau = dtp_DateSchedule.Value;
            lichtrinh.BayDen = baydenhaydi;
            db.LichTrinhs.InsertOnSubmit(lichtrinh);
            db.SubmitChanges();
            LoadGridViewSchedule();
            TimeSpan add1 = new TimeSpan(0, 20, 0);
            TimeSpan add2 = new TimeSpan(0, 25, 0);
            TimeSpan add3 = new TimeSpan(0, 30, 0);
            TimeSpan add4 = new TimeSpan(0, 5, 0);
            TimeSpan add5 = new TimeSpan(0, 10, 0);
            TimeSpan add6= new TimeSpan(0, 25, 0);
            //Them vao danh dach don khach
            if ("Bay Di".Equals(cmb_ComeOrLeaveSchedule))
                {
                

                
                var chonsanhcho = ((from sanhcho in db.SanhChos
                                    where sanhcho.IDTinhTrang == 3
                                    select sanhcho).Skip(0).Take(1)).Select(a => a.IDSanhCho).Single();
                int idsanhcho = Int32.Parse(chonsanhcho.ToString());
                DonKhach donkhach = new DonKhach();
                donkhach.IDMayBay = idmaybay;
                donkhach.IDSanhCho = idsanhcho;
                donkhach.ThoiGianVaoSanhCho = dtp_TimeSchedule.Value.TimeOfDay;
                donkhach.NgayVaoSanhCho = dtp_DateSchedule.Value;

                donkhach.ThoiGianRaSanhCho = dtp_TimeSchedule.Value.TimeOfDay + add1;
                donkhach.NgayRaSanhCho = dtp_DateSchedule.Value;
                db.DonKhaches.InsertOnSubmit(donkhach);
                db.SubmitChanges();
                LoadGridViewPickUpPassenger();

                //Them vao danh sach vao duong lan

                
                var chonduonglan = ((from duonglan in db.DuongLans
                                     join duongbay in db.DuongBays
                                     on duonglan.IDDuongBay equals duongbay.IDDuongBay
                                     join huongbay in db.HuongBays
                                     on duongbay.IDDuongBay equals huongbay.IDHuongBay
                                     where duonglan.IDTinhTrang == 3 && huongbay.IDHuongBay == idhuong
                                     select duonglan).Skip(0).Take(1)).Select(a => a.IDDuongLan).Single();
                int idduonglan = Int32.Parse(chonduonglan.ToString());
                VaoDuongLan vaoduonglan = new VaoDuongLan();
                vaoduonglan.IDMayBay = idmaybay;
                vaoduonglan.IDDuongLan = idduonglan;
                vaoduonglan.ThoiGianVaoDuongLan = dtp_TimeSchedule.Value.TimeOfDay + add1;
                vaoduonglan.NgayVaoDuongLan = dtp_DateSchedule.Value;

                vaoduonglan.ThoiGianRaDuongLan = dtp_TimeSchedule.Value.TimeOfDay + add2;
                vaoduonglan.NgayRaDuongLan = dtp_DateSchedule.Value;
                db.VaoDuongLans.InsertOnSubmit(vaoduonglan);
                db.SubmitChanges();
                LoadGridViewComeToBranch();


                //Cach canh
                
                var chonduongbang = ((from duongbang in db.DuongBays
                                      join huongbay in db.HuongBays
                                      on duongbang.IDHuongBay equals huongbay.IDHuongBay
                                      where duongbang.IDTinhTrang == 3 && huongbay.IDHuongBay == idhuong
                                      select duongbang).Skip(0).Take(1)).Select(a => a.IDDuongBay).Single();
                int idduongbang = Int32.Parse(chonduongbang.ToString());
                CachCanh cachcanh = new CachCanh();
                cachcanh.IDMayBay = idmaybay;
                cachcanh.IDDuongBay = idduongbang;
                cachcanh.ThoiGianVaoDuongBang = dtp_TimeSchedule.Value.TimeOfDay + add2;
                cachcanh.NgayVaoDuongBang = dtp_DateSchedule.Value + add3;

                cachcanh.ThoiGianRaDuongBang = dtp_TimeSchedule.Value.TimeOfDay + add3;
                cachcanh.NgayRaDuongBang = dtp_DateSchedule.Value;
                db.CachCanhs.InsertOnSubmit(cachcanh);
                db.SubmitChanges();
                LoadGridViewWayoff();
            }
            else
            {
                
                
                var chonsanhcho = ((from sanhcho in db.SanhChos
                                    where sanhcho.IDTinhTrang == 3
                                    select sanhcho).Skip(0).Take(1)).Select(a => a.IDSanhCho).Single();
                int idsanhcho = Int32.Parse(chonsanhcho.ToString());
                //Ha canh
                
                var chonduongbang = ((from duongbang in db.DuongBays
                                      join huongbay in db.HuongBays
                                      on duongbang.IDHuongBay equals huongbay.IDHuongBay
                                      where duongbang.IDTinhTrang == 3 && huongbay.IDHuongBay == idhuong
                                      select duongbang).Skip(0).Take(1)).Select(a => a.IDDuongBay).Single();
                int idduongbang = Int32.Parse(chonduongbang.ToString());
                HaCanh hacanh = new HaCanh();
                hacanh.IDMayBay = idmaybay;
                hacanh.IDDuongBay = idduongbang;
                hacanh.GioiGianVaoDuongBang = dtp_TimeSchedule.Value.TimeOfDay;
                hacanh.NgayVaoDuongBang = dtp_DateSchedule.Value;
                hacanh.ThoiGianRaDuongBang = dtp_TimeSchedule.Value.TimeOfDay + add4;
                hacanh.NgayRaDungBang = dtp_DateSchedule.Value;
                db.HaCanhs.InsertOnSubmit(hacanh);
                db.SubmitChanges();
                LoadGridViewLanding();

                //Them vao danh sach vao duong lan
                var chonduonglan = ((from duonglan in db.DuongLans
                                     join duongbay in db.DuongBays
                                     on duonglan.IDDuongBay equals duongbay.IDDuongBay
                                     join huongbay in db.HuongBays
                                     on duongbay.IDDuongBay equals huongbay.IDHuongBay
                                     where duonglan.IDTinhTrang == 3 && huongbay.IDHuongBay == idhuong
                                     select duonglan).Skip(0).Take(1)).Select(a => a.IDDuongLan).Single();
                int idduonglan = Int32.Parse(chonduonglan.ToString());
                VaoDuongLan vaoduonglan = new VaoDuongLan();
                vaoduonglan.IDMayBay = idmaybay;
                vaoduonglan.IDDuongLan = idduonglan;
                vaoduonglan.ThoiGianVaoDuongLan = dtp_TimeSchedule.Value.TimeOfDay + add4;
                vaoduonglan.NgayVaoDuongLan = dtp_DateSchedule.Value;

                vaoduonglan.ThoiGianRaDuongLan = dtp_TimeSchedule.Value.TimeOfDay + add5;
                vaoduonglan.NgayRaDuongLan = dtp_DateSchedule.Value;
                db.VaoDuongLans.InsertOnSubmit(vaoduonglan);
                db.SubmitChanges();
                LoadGridViewComeToBranch();

                //tra khach
                TraKhach trakhach = new TraKhach();
                trakhach.IDMayBay = idmaybay;
                trakhach.IDSanhCho = idsanhcho;
                trakhach.ThoiGianVaoSanhCho = dtp_TimeSchedule.Value.TimeOfDay;
                trakhach.NgayVaoSanhCho = dtp_DateSchedule.Value;

                trakhach.ThoiGianRaSanhCho = dtp_TimeSchedule.Value.TimeOfDay + add5;
                trakhach.NgayRaSanhCho = dtp_DateSchedule.Value;
                db.TraKhaches.InsertOnSubmit(trakhach);
                db.SubmitChanges();
                LoadGridViewLeavePassenger();

            }

        }
    }
}
