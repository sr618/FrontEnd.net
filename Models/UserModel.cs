namespace proj0.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; } = "default.jpg";
        public string Modified { get; set; }
        public string Created { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsAdmin { get; set; } = false;
        public string address { get; set; }
         public int Pincode { get; set; }
    }
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
