using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Classes
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        // 자동 구현 속성
        // 컴파일러가 내부적으로 읽기/쓰기가 가능한 private 백핑 필드(Backed Field)를 자동으로 생성
        // 자동 구현 속성을 사용할 경우, 속성에 대한 별도의 로직(검증 등)을 추가할 수 없다는 한계가 있음
        public string Name { get; set; }
        public string Email { get; set; }   
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }
}
