using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Commando.Colors;
using Commando.Figures;

namespace Commando.Table
{
    public class TablePrinter
    {
        private string[] Header { get; set; }
        private string[] Footer { get; set; }
        private List<string[]> Rows { get; set; }
        public TablePrinter(params string[] columnHeaders)
        {
            Header = columnHeaders;
            Rows = new List<string[]>();
            Footer = new string[0];
        }

        public void AddRow(params string[] columns)
        {
            if (columns.Length != Header.Length)
            {
                throw new ArgumentException("Column length does not match header.");
            }

            Rows.Add(columns);
        }

        public void AddFooter(params string[] columnFooter)
        {
            Footer = columnFooter;
        }

        public void Print()
        {
            var columnWidths = GetColumnWidths();

            var str = GetRow(columnWidths, Figure.PipeUpperLeftCorner, Figure.PipeHorizontalWithTop, Figure.PipeUpperRightCorner);

            for (var i = 0; i < Header.Length; i++)
            {
                var h = Header[i].Green();
                str += string.Format("{0} {1, " + -1 * columnWidths[i] + "}", Figure.PipeVertical, Header[i]).Replace(Header[i], h);
            }

            str += " " + Figure.PipeVertical + Environment.NewLine;
            str += GetRow(columnWidths, Figure.PipeLeftCross, Figure.PipeCross, Figure.PipeRightCross);

            for (var j = 0; j < Rows.Count; j++)
            {
                var row = Rows[j];
                for (var i = 0; i < row.Length; i++)
                {
                    str += string.Format("{0} {1, " + -1 * columnWidths[i] + "}", Figure.PipeVertical, row[i]);
                }
                str += " " + Figure.PipeVertical + Environment.NewLine;
                if (j < Rows.Count - 1)
                {
                    str += GetRow(columnWidths, Figure.PipeLeftCross, Figure.PipeCross, Figure.PipeRightCross);
                }
            }

            str += (Footer.Length > 0)
                ? GetRow(columnWidths, Figure.PipeLeftCross, Figure.PipeCross, Figure.PipeRightCross)
                : GetRow(columnWidths, Figure.PipeLowerLeftCorner, Figure.PipeHorizontalWithBottom, Figure.PipeLowerRightCorner);

            for (var i = 0; i < Footer.Length; i++)
            {
                var footerCell = Footer[i];
                var h = footerCell.Cyan();
                if (footerCell.Length == 0)
                {
                    str += string.Format("{0} {1, " + -1 * columnWidths[i] + "}", Figure.PipeVertical, footerCell);
                }
                else
                {
                    str += string.Format("{0} {1, " + -1 * columnWidths[i] + "}", Figure.PipeVertical, footerCell).Replace(footerCell, h);
                }
            }
            if (Footer.Length > 0)
            {
                str += " " + Figure.PipeVertical + Environment.NewLine;
                str += GetRow(columnWidths, Figure.PipeLowerLeftCorner, Figure.PipeHorizontalWithBottom, Figure.PipeLowerRightCorner);
            }

            Console.WriteLine(str);
        }

        private static string GetRow(int[] columnWidths, char start, char delimiter, char end)
        {
            var str = start.ToString();
            for (var i = 0; i < columnWidths.Length; i++)
            {
                var colWidth = columnWidths[i];
                str += new string(Figure.PipeHorizontal, colWidth + 1);
                if (i < columnWidths.Length - 1)
                {
                    str += delimiter;
                }
            }
            str += $"{Figure.PipeHorizontal}{end}{Environment.NewLine}";
            return str;
        }

        private int[] GetColumnWidths()
        {
            var columnWidths = new int[Header.Length];

            for (var i = 0; i < Header.Length; i++)
            {
                columnWidths[i] = Header[i].Length;
            }

            for (var i = 0; i < Footer.Length; i++)
            {
                if (Footer[i].Length > columnWidths[i])
                {
                    columnWidths[i] = Footer[i].Length;
                }
            }


            foreach (var row in Rows)
            {
                for (var i = 0; i < row.Length; i++)
                {
                    if (row[i].Length > columnWidths[i])
                    {
                        columnWidths[i] = row[i].Length;
                    }
                }
            }

            return columnWidths.Select(x => x + 2).ToArray();
        }
    }
}