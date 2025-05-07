using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.Taf.Core.Logging;
using Unicorn.UI.Core.Controls;
using Unicorn.UI.Core.Controls.Interfaces;
using Unicorn.UI.Core.Controls.Interfaces.Typified;
using Unicorn.UI.Core.Driver;
using Unicorn.UI.Core.PageObject;
using Unicorn.UI.Web.Controls;

namespace Company.WebModule
{
#if (Custom)
    public class NewUserControl : WebControl
#endif
#if (Checkbox)
    public class NewUserControl : WebControl, ICheckbox
#endif
#if (Window)
    public class NewUserControl : WebControl, IWindow
#endif
#if (ListView)
    public class NewUserControl : WebControl, IItemSelectable, IHasItems
#endif
#if (Dropdown)
    public class NewUserControl : WebControl, IItemSelectable, IHasItems, IExpandable
#endif
#if (DataGrid)
    public class NewUserControl : WebControl, IDataGrid
#endif
    {
#if (Custom)
        [Name("element-name")]
        [Find(Using.WebXpath, "LOCATOR")]
        public WebControl InnerElement { get; set; }                        // TODO: <--------- Specify locator
#endif
#if (Checkbox)
        public bool Checked => GetAttribute("class").Contains("checked");   // <--------- Specify custom condition if needed

        public bool SetCheckedState(bool isChecked) =>
            isChecked ? Check() : Uncheck();

        public bool Check()
        {
            ULog.Debug("Check {0}", this);

            if (Checked)
            {
                ULog.Trace("No need to check (checked by default)");
                return false;
            }

            Click();                                                        // <--------- Implement custom check action if needed

            ULog.Trace("Checkbox has been checked");
            
            return true;
        }

        public bool Uncheck()
        {
            ULog.Debug("Uncheck {0}", this);

            if (!Checked)
            {
                ULog.Trace("No need to uncheck (unchecked by default)");
                return false;
            }

            Click();                                                        // <--------- Implement custom uncheck action if needed

            ULog.Trace("Checkbox has been unchecked");

            return true;
        }
#endif
#if (Window)
        [Name("modal title")]
        [Find(Using.WebXpath, "LOCATOR")]           // TODO: <--------- Specify locator
        private readonly WebControl _windowTitle;

        [Name("close button")]
        [Find(Using.WebCss, "LOCATOR")]             // TODO: <--------- Specify locator
        private readonly WebControl _closeButton;

        public string Title => _windowTitle.Text;

        public void Close()
        {
            ULog.Debug("Closing {0}", this);
            _closeButton.Click();
        }
            
#endif
#if (Dropdown)
        [Name("dropdown option")]
        [Find(Using.WebXpath, "LOCATOR")]           // TODO: <--------- Specify locator
        private readonly IList<WebControl> _dropdownItems;

        [Name("expand/collapse button")]
        [Find(Using.WebCss, "LOCATOR")]             // TODO: <--------- Specify locator
        private readonly WebControl _expandCollapseButton;

        [Name("selected value")]
        [Find(Using.WebCss, "LOCATOR")]             // TODO: <--------- Specify locator
        private readonly WebControl _selectedValue;

        [Name("options container")]
        [Find(Using.WebCss, "LOCATOR")]             // TODO: <--------- Specify locator
        private readonly WebControl _optionsContainer;

        public string SelectedValue => _selectedValue.Text.Trim();

        public IList<string> Items => _dropdownItems.Select(i => i.Text.Trim()).ToList();

        public bool Expanded => GetAttribute("class").Contains("open"); // <--------- Specify custom condition if needed

        public bool Expand()
        {
            bool needToExpand = !Expanded;

            if (needToExpand)
            {
                ULog.Trace("Expanding dropdown.");
                _expandCollapseButton.Click();
            }

            return needToExpand;
        }

        public bool Collapse()
        {
            bool needToCollapse = Expanded;

            if (needToCollapse)
            {
                ULog.Trace("Collapsing dropdown.");
                _expandCollapseButton.Click();
            }

            return needToCollapse;
        }

        public bool Select(string itemName)
        {
            ULog.Debug("Select '{0}' item from {1}", itemName, this);

            if (SelectedValue.Equals(itemName)) 
            {
                ULog.Trace("No need to select (the item is selected by default)");
                return false;
            }

            Expand();
            GetOption(itemName).Click();
            Collapse();
            
            ULog.Trace("The item has been selected");
            return true;
        }


        private WebControl GetOption(string itemName)
        {
            throw new System.NotImplementedException("Implement me...");    // TODO: <--------- Implement logic to get an item by name
        }
#endif
#if (ListView)
        [Name("element-name")]
        [Find(Using.WebCss, "LOCATOR")]                 // TODO: <--------- Specify locator
        private readonly IList<WebControl> _menuItems;

        [Name("selected value")]
        [Find(Using.WebCss, "LOCATOR")]                 // TODO: <--------- Specify locator
        private readonly WebControl _selectedValue;

        public string SelectedValue                     // <--------- Implement logic to get selected value if needed
        {
            get
            {
                if (TryGetChild(_selectedValue.Locator))
                {
                    return _selectedValue.Text.Trim();
                }

                return "";
            }
        }

        public IList<string> Items => _menuItems.Select(i => i.Text.Trim()).ToList();

        public bool Select(string itemName)
        {
            ULog.Debug("Select '{0}' item from {1}", itemName, this);

            if (SelectedValue.Equals(itemName)) 
            {
                ULog.Trace("No need to select (the item is selected by default)");
                return false;
            }

            WebControl item = GetItem(itemName);

            item.Click();
            ULog.Trace("Item has been selected");
            return true;
        }

        private WebControl GetItem(string itemName)
        {
            throw new System.NotImplementedException("Implement me...");    // TODO: <--------- Implement logic to get an item by name
        }
#endif
#if (DataGrid)
        [Name("Grid header")]
        [Find(Using.WebCss, "LOCATOR")]                                 // TODO: <--------- Specify locator
        private readonly Header _header;

        public int RowsCount => HasRows ? Rows.Count() : 0;

        public bool HasRows => TryGetChild(ByLocator.Css("LOCATOR"));   // TODO: <--------- Specify locator

        [Name("Grid row")]
        [Find(Using.WebCss, "LOCATOR")]                                 // TODO: <--------- Specify locator
        public IList<Row> Rows { get; set; }

        public IDataGridCell GetCell(int rowIndex, int columnIndex) =>
            GetRow(rowIndex).GetCell(columnIndex);

        public IDataGridCell GetCell(int rowIndex, string columnName) =>
            GetRow(rowIndex).GetCell(_header.GetColumnIndex(columnName));

        public IDataGridCell GetCell(string searchColumnName, string searchCellValue, string targetColumnName) =>
            GetRow(searchColumnName, searchCellValue)
            .GetCell(_header.GetColumnIndex(targetColumnName));

        public IDataGridRow GetRow(int rowIndex) =>
            HasRows && rowIndex < RowsCount ?
                Rows.ElementAt(rowIndex) :
                throw new ControlNotFoundException($"Row with index {rowIndex} does not exist.");

        public IDataGridRow GetRow(string columnName, string cellValue)
        {
            int columnIndex = _header.GetColumnIndex(columnName);

            Row row = HasRows ?
                Rows.FirstOrDefault(r => r.GetCell(columnIndex).Data.Equals(cellValue)) :
                null;

            return row ?? throw new ControlNotFoundException($"Row where '{columnName}' = '{cellValue}' does not exist.");
        }

        public IDataGridRow GetRow(int columnIndex, string cellValue)
        {
            var row = HasRows ?
            Rows.FirstOrDefault(r => r.GetCell(columnIndex).Data.Equals(cellValue)) :
            null;

            return row ?? throw new ControlNotFoundException($"Row where cell with index '{columnIndex}' = '{cellValue}' does not exist.");
        }

        public void SortBy(string columnName, SortDirection direction)
        {
            WebControl column = _header.GetColumnControl(columnName);

            int clicksNumber = System.Math.Abs(direction - _header.GetColumnSorting(column));

            for (int i = 0; i < clicksNumber; i++)
            {
                column.Click();
            }
        }

        public bool HasCell(string searchColumnName, string searchCellValue, string targetColumnName)
        {
            try
            {
                GetCell(searchColumnName, searchCellValue, targetColumnName);
                return true;
            }
            catch (ControlNotFoundException)
            {
                return false;
            }
        }

        public bool HasColumn(string columnName)
        {
            try
            {
                _header.GetColumnControl(columnName);
                return true;
            }
            catch (ControlNotFoundException)
            {
                return false;
            }
        }

        public bool HasRow(string columnName, string cellValue)
        {
            try
            {
                GetRow(columnName, cellValue);
                return true;
            }
            catch (ControlNotFoundException)
            {
                return false;
            }
        }

        public class Header : WebControl
        {
            public int GetColumnIndex(string columnName)
            {
                TimeSpan originalTimeout = ImplicitWaitTimeout;
                ImplicitWaitTimeout = TimeSpan.Zero;

                try
                {
                    throw new System.NotImplementedException("Implement me...");    // TODO: <--------- Implement logic to identify column sort direction
                    
                    // need to use locator to get all preceding-siblings for the column with specified name
                    ByLocator locator = ByLocator.Xpath(string.Format("SOME_XPATH_TEMPLATE", columnName));

                    return FindList<WebControl>(locator).Count;
                }
                catch (Exception)
                {
                    throw new ControlNotFoundException($"Column '{columnName}' does not exist.");
                }
                finally
                {
                    ImplicitWaitTimeout = originalTimeout;
                }
            }

            public WebControl GetColumnControl(string columnName)
            {
                throw new System.NotImplementedException("Implement me...");    // TODO: <--------- Implement logic to get a column by name
            }

            public bool IsColumnSorted(WebControl columnHeader, SortDirection direction)
            {
                throw new System.NotImplementedException("Implement me...");    // TODO: <--------- Implement logic to identify column sort direction
            }

            public SortDirection GetColumnSorting(WebControl columnHeader)
            {
                throw new System.NotImplementedException("Implement me...");    // TODO: <--------- Implement logic to get column sorting direction

                string sortingValue = "IMPLEMENT_ME";

                return sortingValue switch
                {
                    "NONE_CASE" => SortDirection.NotSorted,
                    "ASC_CASE" => SortDirection.Ascending,
                    "DESC_CASE" => SortDirection.Descending,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        public class Row : WebControl, IDataGridRow
        {
            [Find(Using.WebCss, "LOCATOR")]                                     // TODO: <--------- Specify locator
            private readonly IList<Cell> _cellsList;

            public IDataGridCell GetCell(int index) =>
                index < _cellsList.Count ?
                    _cellsList[index] :
                    throw new ControlNotFoundException($"Cell with index {index} does not exist.");
        }

        public class Cell : WebControl, IDataGridCell
        {
            public string Data => Text.Trim();
        }
#endif
    }
}
