using System;
using Games.Common;

namespace BusinessLayer.Contracts
{
    /// <summary>
    /// Класс, показывающий успешность операции
    /// </summary>
    /// <typeparam name="TResult">Тип данных возвращаемых в результате операции</typeparam>
    public class OperationResult<TResult>
    {
        /// <summary>
        /// Данные возвращаемые в случае если операция прошла успешно
        /// </summary>
        public static OperationResult<TResult> Ok(TResult result)
        {
            return new OperationResult<TResult>()
            {
                Success = true,
                Result = result
            };
        }

        public TResult Result { get; set; }
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Получить список ошибок в случае, если операция завершилась неудачно
        /// </summary>
        public string GetErrors()
        {
            return string.Join(Environment.NewLine, Errors);
        }
    }
}
