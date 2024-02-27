using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloppyJoe
{
    class MenuItem
    {
        public static Random Randomizer = new Random(12345);
        // 12345: 12345는 랜덤 숫자 생성기(Random)의 시드(seed) 값
        // 랜덤 숫자 생성기는 시드 값을 기반으로 무작위 수열을 생성
        // 시드 값을 동일하게 유지하면, 동일한 순서의 "랜덤" 숫자들이 생성
        // 여러개의 Randomizer가 거의 동시에 instance를 생성할 때, 같은 Seed를 갖고 Next를 호출해 같은 값을 갖게되는 문제 발생
        // static을 추가해서 하나의 random instance 공유
        // Randomizer.next()를 호출할 때마다 시퀀스 내의 다음 숫자를 반환

        public string[] Proteins =
        {
            "Roast Beef", "Salami", "Turkey", "Ham", "Pastrami", "Tofu"
        };
        public string[] Condiments =
        {
            "yellow mustard", "brown mustard", "honey mustard", "mayo", "relish", "french dressing"
        };
        public string[] Breads = 
        { 
            "rye", "white", "wheat", "pumpernickel", "a roll" 
        };

        public string Description = "";
        public string Price;

        public void Generate()
        {
            string randomProtein = Proteins[Randomizer.Next(Proteins.Length)];
            string randomCondiment = Condiments[Randomizer.Next(Condiments.Length)];
            string randomBread = Breads[Randomizer.Next(Breads.Length)];

            Description = randomProtein + " with " + randomCondiment + " on " + randomBread;

            decimal bucks = Randomizer.Next(2, 5);
            decimal cents = Randomizer.Next(1, 98);
            decimal price = bucks + (cents * 0.01M);

            var usCultueInfo = new CultureInfo("en-US");
            Price = price.ToString("c", usCultueInfo);
        }

    }
}
