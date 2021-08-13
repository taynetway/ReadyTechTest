using System.Threading.Tasks;

namespace WebApp.ThirdPartyAPI
{

    public interface IWeatherAPI {

        public string City { get; set; }
        public string  ApiCode { get; set;}

        public Task<float> GetTemperature();
    }
}
