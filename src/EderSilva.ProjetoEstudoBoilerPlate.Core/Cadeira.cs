using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace EderSilva.ProjetoEstudoBoilerPlate
{
    //Herdamos a classe Entity do ABP, esta classe simplesmente possui a nossa chave primária
    //A interface IHasCreationTime é responsável por obrigar a classe a possuir a propriedade CreationTime
    [Table("AppCadeiras")]
    public class Cadeira : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024;

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }
        
        public CadeiraState State { get; set; }

        public Cadeira()
        {
            CreationTime = Clock.Now;
            State = CadeiraState.Open;
        }
    }

    public enum CadeiraState: byte
    {
        Open = 0,
        Completed = 1
    }
}
