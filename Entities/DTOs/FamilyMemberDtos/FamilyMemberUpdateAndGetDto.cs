using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.FamilyMemberDtos
{
    public class FamilyMemberUpdateAndGetDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public string RelationShip { get; set; } = null!;

        public string MemberName { get; set; } = null!;

        public string MemberSurName { get; set; } = null!;

        public string MemberPatronymic { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public string BirthPlace { get; set; } = null!;

        public string Occupation { get; set; } = null!;
    }
}
