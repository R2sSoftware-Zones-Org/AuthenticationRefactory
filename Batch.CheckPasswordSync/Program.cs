using Model.Eneity;
using Model.Entity;
using Model.Service;
using Model.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batch.CheckPasswordSync
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.取得欲比對帳號密碼的清單
            SyncService syncService = new SyncService();
            IList<Profile> profileCollection = syncService.GetCheckList();

            //2.檢查是否與Authentication的資料一致
            StringBuilder mailContent = new StringBuilder();
            mailContent.AppendLine(string.Format("檢查時間:{0}", System.DateTime.Now.ToString()));

            AuthenticationService authenticationService = new AuthenticationService();
            bool IsAnyError = false;

            foreach (var item in profileCollection)
            {
                //3.將不一致的資料記錄下來,發送Email
                if (authenticationService.VerifyPasswordById(item.Id, item.Password) != VerifyStatus.Passed)
                {
                    string message = string.Format("同步異常的帳號:{0}", item.Id);
                    mailContent.AppendLine(message);
                    IsAnyError = true;
                }
            }

            //4.如果有不一致的資料,則發送通知
            if (IsAnyError)
            {
                AlertService alertService = new AlertService();
                alertService.Alert(mailContent.ToString());
            }


        }
    }
}
