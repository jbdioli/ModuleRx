using System.Collections.Generic;
using System.Linq;
using ModuleRx.Models_Dto;
using ModuleRx.Models_View;

namespace ModuleRx.Shared
{
    public class CopyModel
    {
        public void CopyInfosDtoToViewModel(List<InfoDto> infosDto, List<InfoViewModel> infosView)
        {
            if (infosDto == null || infosView == null)
                return;
            infosView.AddRange(infosDto.Select(infoDto => new InfoViewModel() { UserId = infoDto.UserId, Id = infoDto.Id, Title = infoDto.Title, Body = infoDto.Body }));
        }


        public void CopyInfoViewModelToDto(InfoViewModel infoView, InfoDto infoDto)
        {
            if (infoView == null || infoDto == null)
                return;
            infoDto.UserId = infoView.UserId;
            infoDto.Id = infoView.Id;
            infoDto.Title = infoView.Title;
            infoDto.Body = infoView.Body;
        }
    }
}