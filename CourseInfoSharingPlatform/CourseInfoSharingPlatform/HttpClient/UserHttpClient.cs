﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using CourseInfoSharingPlatform.Models;

namespace CourseInfoSharingPlatform.ClientHttp
{
    class UserHttpClient
    {
        private HttpClient HttpClient { get; set; }
        private static UserHttpClient UserHttp { get; set; }
        private static bool IsStu; 
        private static User CurrentStu { get; set; }
        private static Admin CurrentAdmin { get; set; }




        private UserHttpClient() {
            //以下为测试代码，实际运行删除
            /*
            CurrentAdmin.AdminName = "testAdmin";
            CurrentAdmin.Password =  "admin";
            CurrentStu.UserName = "testStu";
            CurrentStu.Password = "stu";
            */
        }
        

        public static UserHttpClient GetInstance()
        {
            //单例模式
            if (UserHttp == null)
            {
                UserHttp = new UserHttpClient();
                UserHttp.HttpClient = new HttpClient();
                UserHttp.HttpClient.DefaultRequestHeaders.Accept.Clear();
                UserHttp.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //以下为测试代码，实际运行删除
                CurrentAdmin = new Admin();
                CurrentStu = new User();
                CurrentAdmin.AdminName = "testAdmin";
                CurrentAdmin.Password =  "admin";
                CurrentStu.UserName = "testStu";
                CurrentStu.Password = "stu";
               


            }
            return UserHttp;

        }

        private static string baseUrl = "https://localhost:44386/api/user";

        public static bool LikedCourse(string url,string courseId,string userName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("courseId", courseId);
            d.Add("userName", userName);
            var result = ClientHttp.GET(url, d);
            bool flag = (bool)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(bool));
            return flag;
        }

        //判断用户是否收藏课程
        public static bool IsLikedCourse(string courseId,string userName)
        {
            string url = baseUrl + "/isLikedCourse";
            return LikedCourse(url, courseId, userName);
        }
        //用户收藏课程
        public static bool AddFavoriteCourse(string courseId,string userName)
        {
            string url = baseUrl + "/addLikeCourse";
            return LikedCourse(url, courseId, userName);
        }

        // 获取用户给课程打分
        public static int GetScore(string courseId, string userName)
        {
            string url = baseUrl + "/getScore";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("courseId", courseId);
            d.Add("userName", userName);
            var result = ClientHttp.GET(url, d);
            int score = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(int));
            return score;
        }

        // 用户给课程打分
        public static bool AddScore(string courseId, string userName, int score)
        {
            string url = baseUrl + "/addScore";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("courseId", courseId);
            d.Add("userName", userName);
            d.Add("score", score.ToString());
            var result = ClientHttp.GET(url, d);
            bool flag = (bool)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(bool));
            return flag;
        }

        //验证用户，并保存信息
        public async Task<bool> AuthenticateAsync(string username,string password,bool isStu)
        {
            IsStu = isStu;
            
            if (isStu)
            {
                string url = Properties.Settings.Default.baseUrl + Properties.Settings.Default.stuUrl
                               + "?name=" + username + "&&password=" + password;

                string result = await ClientHttp.GetUser(url);
                CurrentStu = JsonConvert.DeserializeObject<User>(result);
 
                return CurrentStu == null;
            }
            else
            {
                string url = Properties.Settings.Default.baseUrl + Properties.Settings.Default.adminUrl
                               + "?name=" + username + "&&password=" + password;
                string result = await ClientHttp.GetUser(url);
                CurrentAdmin = JsonConvert.DeserializeObject<Admin>(result);
                return CurrentAdmin == null;
            }

        }
        //创建用户
        public async Task<bool> CreateAccount(User user)
        {
            string url = Properties.Settings.Default.baseUrl + Properties.Settings.Default.stuUrl;
            bool res = await ClientHttp.PostUser(url, JsonConvert.SerializeObject(user));
            return res;
        }
        public async Task<bool> CreateAccount(Admin admin)
        {
            string url = Properties.Settings.Default.baseUrl + Properties.Settings.Default.adminUrl;
            bool res = await ClientHttp.PostUser(url, JsonConvert.SerializeObject(admin));
            return res;
        }
<<<<<<< HEAD

        // 删除用户喜爱课程
        public static bool DeleteFavouriteCourse(string userName, string courseId)
        {
            string url = baseUrl + "/deleteFavouriteCourse"; 
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("userName", userName);
            d.Add("courseId", courseId.ToString());
            var result=ClientHttp.GET(url, d);
            return bool.Parse(result);
        }

=======
>>>>>>> 9ce2c645a6b0486ea6342255a2dc97ff7f466682
        //修改个人信息,为方便不包括用户名密码的User
        public async Task<bool> ModifyInformation(User NewUser)
        {
            if (IsStu)
            {
                NewUser.UserName = CurrentStu.UserName;
                NewUser.Password = CurrentStu.Password;
                CurrentStu = NewUser;
                string url = Properties.Settings.Default.baseUrl + Properties.Settings.Default.stuUrl + "/" + CurrentStu.UserName;
                bool res = await ClientHttp.PutUser(url, JsonConvert.SerializeObject(NewUser));
                
                return res;
                
            }
            return true;
        }
        
        //修改密码
        public async Task<bool> ResetPassword(string oldPwd,string newPwd)
        {
            if (IsStu)
            {
                if (oldPwd != CurrentStu.Password)
                    return false;
                CurrentStu.Password = newPwd;
                string url = Properties.Settings.Default.baseUrl + Properties.Settings.Default.stuUrl + "/" +CurrentStu.UserName;
                bool res = await ClientHttp.PutUser(url, JsonConvert.SerializeObject(CurrentStu));

                return res;
            }
            else
            {
                if (oldPwd != CurrentAdmin.Password)
                    return false;
                CurrentAdmin.Password = newPwd;
                string url = Properties.Settings.Default.baseUrl + Properties.Settings.Default.adminUrl + "/" + CurrentAdmin.AdminName;
                bool res = await ClientHttp.PutUser(url, JsonConvert.SerializeObject(CurrentAdmin));

                return res;
            }
        }
        //注销账户
        public async Task<bool> DeleteAccount()
        {
            if (IsStu)
            {
              
                string url = Properties.Settings.Default.baseUrl + Properties.Settings.Default.stuUrl + "/" + CurrentStu.UserName;
                bool res = await ClientHttp.DeleteUser(url);

                return res;
            }
            else
            {
                string url = Properties.Settings.Default.baseUrl + Properties.Settings.Default.adminUrl + "/" + CurrentAdmin.AdminName;
                bool res = await ClientHttp.DeleteUser(url);

                return res;
            }
        }

        public User GetUser()
        {
            if (IsStu)
                return CurrentStu;
            else return null;
        }
        public Admin GetAdmin()
        {
            if (!IsStu)
                return CurrentAdmin;
            else return null;
        }
        public string GetName()
        {
            if (IsStu)
                return CurrentStu.UserName;
            else return CurrentAdmin.AdminName;
        }
    }
}
