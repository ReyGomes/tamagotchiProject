using Newtonsoft.Json;
using RestSharp;
using System.Text.Json;
using tamagotchiProject.Controller;
using tamagotchiProject.Model;
namespace tamagotchiProject
{
    class Program
    {
        static void Main(string[] args)
        {
            TamagotchiContoller tamagotchiContoller = new TamagotchiContoller();
            tamagotchiContoller.Jogar();
        }
    }

}