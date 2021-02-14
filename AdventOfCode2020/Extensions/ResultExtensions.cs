using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Extensions
{
    public static class ResultExtensions
    {
        public static bool IsSuccess<T>(this Result<T> result)
            => result.Status == ResultStatus.Ok;
    }
}
