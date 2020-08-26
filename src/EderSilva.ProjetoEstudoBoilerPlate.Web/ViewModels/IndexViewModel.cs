using Abp.Localization;
using EderSilva.ProjetoEstudoBoilerPlate.DTO;
using EderSilva.ProjetoEstudoBoilerPlate.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EderSilva.ProjetoEstudoBoilerPlate.Web.ViewModels
{
    public class IndexViewModel
    {
        public IReadOnlyList<CadeiraListDto> Cadeiras { get; }
        public IndexViewModel(IReadOnlyList<CadeiraListDto> cadeiras)
        {
            Cadeiras = cadeiras;
        }

        //public CadeiraState? SelectedCadeiraState { get; set; }

        public List<SelectListItem> GetCadeirasStateSelectListItems(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
        {
            new SelectListItem
            {
                Text = localizationManager.GetString(ProjetoEstudoBoilerPlateConsts.LocalizationSourceName, "AllTasks"),
                Value = ""//,
                //Selected = SelectedCadeiraState == null
            }
        };

            list.AddRange(Enum.GetValues(typeof(CadeiraState))
                    .Cast<CadeiraState>()
                    .Select(state =>
                        new SelectListItem
                        {
                            Text = localizationManager.GetString(ProjetoEstudoBoilerPlateConsts.LocalizationSourceName, $"TaskState_{state}"),
                            Value = state.ToString()//,
                            //Selected = state == SelectedCadeiraState
                        })
            );

            return list;
        }

        public string GetCadeiraLabel(CadeiraListDto cadeira)
        {
            switch (cadeira.State)
            {
                case CadeiraState.Open:
                    return "label-sucess";
                default:
                    return "lebel-default";
            }
        }
    }
}
