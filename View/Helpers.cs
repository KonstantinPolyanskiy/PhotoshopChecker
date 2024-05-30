using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoshopChecker.View
{
   
    public class Helpers
    {
        public enum ResultStatus
        {
            Good,
            Warning,
            Error,
        }

        /// <summary>
        /// Выводит в Label отформатированный результат
        /// </summary>
        /// <param name="rawResult">Строка, которую необходимо отрисовать</param>
        /// <param name="label">Label, в которую будет выведен отформатированный текст</param>
        /// <param name="status">Статус, на основе которого определяется форматирование: Good, Warning, Error </param>
        /// <returns>Ogbcfybt возвращаемого значения</returns>
        public static void SetFormattedResult(string rawResult, Label label, ResultStatus status)
        {
            rawResult = rawResult.ToLower();
            label.Text = rawResult;

            switch (status)
            {
                case ResultStatus.Good:
                    label.ForeColor = Color.Green;
                    break;
                case ResultStatus.Warning:
                    label.ForeColor = Color.OrangeRed;
                    break;
                case ResultStatus.Error:   
                    label.ForeColor = Color.Red;
                    break;
                default:
                    label.ForeColor = Color.Red;
                    label.Text = "Некорректный статус";
                    break;
            }
        }

    }
}
