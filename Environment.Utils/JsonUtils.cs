using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BIM_Leaders_Utils
{
    public class JsonUtils
    {
        public struct MyStruct
        {
            public string type { get; set; }
            public string project_id { get; set; }
            public string private_key_id { get; set; }
            public string private_key { get; set; }
            public string client_email { get; set; }
            public string client_id { get; set; }
            public string auth_uri { get; set; }
            public string token_uri { get; set; }
            public string auth_provider_x509_cert_url { get; set; }
            public string client_x509_cert_url { get; set; }
            public string universe_domain { get; set; }
        };

        public static string GetJsonString()
        {
            MyStruct myData = new MyStruct
            {
                type = "service_account",
                project_id = "the-racer-401505",
                private_key_id = "4aa716143c194bea7b4013b2688bac724fdc0ad5",
                private_key = "-----BEGIN PRIVATE KEY-----\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQDuC91QoruTw+tL\n15nYYn+78VUffRshV5Dbc+EphqH0zxnEUlf2iRrYgRct8z6OcA1PQpKGK578EFE9\nx41z9N74pkwxQPPRdBf6Cu1JTLtew3W5MCxIdxo5ou0bauapFcZe0pYKK9dBzTaA\n4ARzLWuJ7pkQHomcDhk9y749F7ijMiBlbey4FSVjIfej/xhoPFkYr+rlhpJNNCai\nBV4OK0X22NzJCig+0e5vT4WaoSCBs4UXJDJ5MyTUu1MmMX8x3CVtrdeeRvWBgn/M\nePUdu/XfwUstYj4KzyREfiQ78OUaw4nEX80+pF3O8gsHv3c28N1YgCSNpuLzonYu\n2JObk/kxAgMBAAECggEAFXnDiylLQ+76dNqsGf306SdCFzepsW3ddzbymtT3Godu\nmywUnHzNC7hFt5MI0z/fq4Vlg64+xx3PvoOYytvOG9+g4xapiH1xRlEjDChchRWc\nMstaS2VXW9jLjFwuGBYLUfWsrJk878ZMQv8y15NC7uw0KeSfZJFPDKirboaL1Ukd\nXIUbTwwOaMJY8BTiB2H6HGKwbpTvlOL6AixnShovPFoe6UBz68//wnkthZVd2IwV\neX/iyLcZ8Fl2ahDALe9k28tslQWKEMn8/xyj50X2KMVgBrW41s4qWen+9sZ11q+D\nv+u190DO+6GEPgRi8tjkpkhevnIv98280IXZ1uHFoQKBgQD+GjzMLW4GeaqDHijw\njmBHTOAntuHQlzl0jcc7ozbQbB2NZiQj7ZUa8clgAKaambFu+UTOr+kX7Hrljhdz\nK6RM37PrKspOH+ddokLHIbzuDGB3134p8ZQ9Ffo3P05LY73tTyR8R8kair6zoQtv\nOWTXhHgbM0O0ZbZHvrzh9DLI6QKBgQDv0u7NRdCPFWy6+Mz+S4RTgcfNsSDMdNs+\nfQGa9Z5CeGEm7gVsEdpGy1rkbTEJ1t16FqBQV0/eCgdI62DkycVU1Wfn+NyIoBq+\nAxX8oNaBqA6W7lUxUtaIAlCJQnTk9fC+iU1VS6/uy2CSXynu9DkbZ5yzC9j/7DeJ\nX9IoebIBCQKBgCe65HysMcLTbSS5J3+NU2Jyk63B+4bIzlP6AwfBGkX2UZyVNttj\nP2gKHAllsKcFlueaE/cZLCHweLrBv8rjLPpUE+aWNzGF7YAHadeG3+p8huzWBcT7\nH8l5UTkoLc691qlvMW45Lyl2PiEJ8ia+25STAtCF8HUZXinTmebebr5ZAoGAHslI\nKIfGzydj7tiTkC1njkTBvnD3keeKYYowk5DmQQgtCI9TmNzt1Vqzj1FJE0dG5S5U\nZBvhP9Kvvregl54jO9GtZgT3Yn6TEENbJjQLdVd6j/uGai+FJK6PYh9q3B2KSxtb\nFxEBQ7lN61xWCLvHPPJfFkj2EVxkgLkRRGri4+kCgYA3SJO/Z3Fbb8a0JXWi/OXb\nzZUNOCUkpRz3hS81Ij8jaiXTwLhg7wFVRWIo0KnDO30+aqjODqaszcM4Mnq+Tuj4\nckvFErqNkNNNBEG0TC5chNMxp1slH/iw7gvly61L529q4ji3kFxdw1f436Roxw4z\nf9YeX9rpX8y33A84xrjiUQ==\n-----END PRIVATE KEY-----\n",
                client_email = "bim-leaders-storage@the-racer-401505.iam.gserviceaccount.com",
                client_id = "108778962124223859611",
                auth_uri = "https://accounts.google.com/o/oauth2/auth",
                token_uri = "https://oauth2.googleapis.com/token",
                auth_provider_x509_cert_url = "https://www.googleapis.com/oauth2/v1/certs",
                client_x509_cert_url = "https://www.googleapis.com/robot/v1/metadata/x509/bim-leaders-storage%40the-racer-401505.iam.gserviceaccount.com",
                universe_domain = "googleapis.com"
            };

            // Serialize the struct to JSON
            string jsonString = JsonConvert.SerializeObject(myData, Formatting.Indented);

            return jsonString;
        }
    }
}
