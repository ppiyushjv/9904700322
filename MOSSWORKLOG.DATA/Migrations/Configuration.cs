namespace MOSSWORKLOG.DATA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MOSSWORKLOG.DATA.MossWorkLogDbEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MOSSWORKLOG.DATA.MossWorkLogDbEntities context)
        {

            //if (!context.tblRoles.Any())
            //{
            //    context.tblRoles.Add(new tblRole() { RoleId = 1,RoleDesc = "Administrator" });
            //    context.tblRoles.Add(new tblRole() { RoleId = 2,RoleDesc = "Client" });
            //    context.tblRoles.Add(new tblRole() { RoleId = 3,RoleDesc = "Manager" });
            //    context.tblRoles.Add(new tblRole() { RoleId = 4,RoleDesc = "Supervisor" });
            //    context.tblRoles.Add(new tblRole() { RoleId = 5,RoleDesc = "User" });
            //}

            //if (!context.tblUsers.Any())
            //{
            //    context.tblUsers.Add(new tblUser() { RoleId = 1, UserId = 1, UserName = "kalpesh", FullName= "Kalpesh Chhatrala",Mobile= "9898296236",email= "kalpesh2804@yahoo.com",Password= "123" });
            //    context.tblUsers.Add(new tblUser() { RoleId = 3, UserId = 2, UserName = "manager", FullName = "manager", Mobile = "manager", email = "manager", Password = "123" });
            //    context.tblUsers.Add(new tblUser() { RoleId = 4, UserId = 3, UserName = "ppiyushjv", FullName = "Piyush Jankidas Vaishnavswami", Mobile = "9904700322", email = "ppiyushjv@hotmail.com", Password = "123" });
            //    context.tblUsers.Add(new tblUser() { RoleId = 5, UserId = 4, UserName = "USER", FullName = "USER ", Mobile = "USER ", email = "USER ", Password = "123" });
            //}

            //if (!context.tblMenus.Any())
            //{
            //    context.tblMenus.Add(new tblMenu() { MainId = "000", SubId = "001", Lable = "Home", Action = "Index", Controller = "Home", Area = "", IconClass = "ti-dashboard", UserRole = null, SerialNo = 1, IsSub = false });
            //    context.tblMenus.Add(new tblMenu() { MainId = "000", SubId = "002", Lable = "Home", Action = "Index", Controller = "Home", Area = "", IconClass = "ti-dashboard", UserRole = null, SerialNo = 1, IsSub = false });
            //    context.tblMenus.Add(new tblMenu() { MainId = "000", SubId = "001", Lable = "Home", Action = "Index", Controller = "Home", Area = "", IconClass = "ti-dashboard", UserRole = null, SerialNo = 1, IsSub = false });
            //    context.tblMenus.Add(new tblMenu() { MainId = "000", SubId = "001", Lable = "Home", Action = "Index", Controller = "Home", Area = "", IconClass = "ti-dashboard", UserRole = null, SerialNo = 1, IsSub = false });
            //    context.tblMenus.Add(new tblMenu() { MainId = "000", SubId = "001", Lable = "Home", Action = "Index", Controller = "Home", Area = "", IconClass = "ti-dashboard", UserRole = null, SerialNo = 1, IsSub = false });

            //}

        }
    }
}
