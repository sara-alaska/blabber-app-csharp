using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BlabberApp.DataStore;
using BlabberApp.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlabberApp.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private UserMySqlDataStore userMySqlDataStore;

        private BlabMySqlDataStore blabMySqlDataStore;


        [BindProperty]
        public UserEntity UserEntity { get; set; }

        [BindProperty]
        public BlabEntity BlabEntity { get; set; }


        [BindProperty]
        public UserModel UserModel { get; set; }

        [BindProperty]
        public static List<BlabEntity> Blabs { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            MySqlDataStoreConnection conn = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=saraalaskarova;Uid=saraalaskarova;Pwd=letmein;"
            );
            userMySqlDataStore = new UserMySqlDataStore(conn);
            blabMySqlDataStore = new BlabMySqlDataStore(conn);
        }

        public void OnGet()
        {

            IDomain[] blabIDomains = blabMySqlDataStore.ReadAll();
            Blabs = new List<BlabEntity>();

            for (int i = 0; i < blabIDomains.Length; i++)
            {
                Blabs.Add((BlabEntity)blabIDomains[i]);
            }

        }


        public async Task<IActionResult> OnPost()
        {
            if (UserModel.Name != null && UserModel.Email != null && BlabEntity.message != null)
            {
                UserEntity userEntity = (UserEntity)userMySqlDataStore.Read(UserModel.Name, UserModel.Email);

                if(userEntity.GetId() == 0)
                {
                    userEntity.Name = UserModel.Name;
                    userEntity.SetSysId(UserModel.Email);
                    userEntity.SetId(userMySqlDataStore.Create(userEntity));
                }

                BlabEntity.userId = userEntity.GetId();
                blabMySqlDataStore.Create(BlabEntity);


               // System.Diagnostics.Debug.WriteLine("message:" + BlabEntity.message);

            }

            return RedirectToPage("Index");
        }

    }
}
