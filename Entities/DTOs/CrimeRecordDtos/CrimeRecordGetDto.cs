using Core.Entities;

namespace Entities.DTOs.CrimeRecordDtos
{
    public class CrimeRecordGetDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public int? MemberId { get; set; }
        public string? MemberName { get; set; }

        public string? MemberSurName { get; set; }

        public string ChargeDescription { get; set; } = null!;

        public string ChargeDuration { get; set; } = null!;

        public string PenalInstitution { get; set; } = null!;

        public string? Record { get; set; }
    }

}
