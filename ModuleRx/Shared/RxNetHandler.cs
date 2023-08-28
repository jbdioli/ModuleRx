using ModuleRx.Models_Dto;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace ModuleRx.Shared
{
    public static class RxNetHandler
    {
        //public static readonly ReplaySubject<List<InfoDto>> InfoSubject = new(1);
        public static readonly RxNetReplaySubject<List<InfoDto>> InfoSubject = new();

    }
}