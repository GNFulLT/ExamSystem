    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    namespace ExamSystem.WpfNetCore.CustomControls
    {
        [TemplatePart(Name = "PART_ListBox", Type = typeof(ListBox))]
        [TemplatePart(Name = "PART_JumpPageTextBox", Type = typeof(TextBox))]
        [TemplatePart(Name = "PART_CountPerPageTextBox", Type = typeof(TextBox))]
        public class Pagination : Control
        {
            private static readonly Type _typeofSelf = typeof(Pagination);


            private ListBox _listBox;
            private TextBox _jumpPageTextBox;
            private TextBox _countPerPageTextBox;

            private const string Ellipsis = "···";

            private static RoutedCommand _prevCommand = null;
            public static RoutedCommand PrevCommand
            {
                get { return _prevCommand; }
            }

            private static RoutedCommand _nextCommand = null;
            public static RoutedCommand NextCommand
            {
                get { return _nextCommand; }
            }

            static Pagination()
            {
                InitializeCommands();
                DefaultStyleKeyProperty.OverrideMetadata(_typeofSelf,
                    new FrameworkPropertyMetadata(_typeofSelf));



            }

            #region Commands
            private static void InitializeCommands()
            {
                _prevCommand = new RoutedCommand("Prev", _typeofSelf);
                _nextCommand = new RoutedCommand("Next", _typeofSelf);

                CommandManager.RegisterClassCommandBinding
                    (_typeofSelf, new CommandBinding(_prevCommand, OnPrevCommand, OnCanPrevCommand));

                CommandManager.RegisterClassCommandBinding
                    (_typeofSelf, new CommandBinding(NextCommand, OnNextCommand, OnCanNextCommand));

            }
            private static void OnPrevCommand(object sender, RoutedEventArgs e)
            {
                var control = sender as Pagination;
                control.Current--;
            }

            private static void OnCanPrevCommand(object sender, CanExecuteRoutedEventArgs e)
            {
                var control = sender as Pagination;
                e.CanExecute = control.Current > 1;
            }

            private static void OnNextCommand(object sender, RoutedEventArgs e)
            {
                var control = sender as Pagination;
                control.Current++;
            }

            private static void OnCanNextCommand(object sender, CanExecuteRoutedEventArgs e)
            {
                var control = sender as Pagination;
                e.CanExecute = control.Current < control.PageCount;
            }
            #endregion

            #region Properties
            private static readonly DependencyPropertyKey PagesPropertyKey =
              DependencyProperty.RegisterReadOnly("Pages", typeof(IEnumerable<string>), _typeofSelf, new PropertyMetadata(null));
            public static readonly DependencyProperty PagesProperty = PagesPropertyKey.DependencyProperty;
            public IEnumerable<string> Pages
            {
                get { return (IEnumerable<string>)GetValue(PagesProperty); }
            }

            private static readonly DependencyPropertyKey PageCountPropertyKey =
               DependencyProperty.RegisterReadOnly("PageCount", typeof(int), _typeofSelf, new PropertyMetadata(1, null));
            public static readonly DependencyProperty PageCountProperty = PageCountPropertyKey.DependencyProperty;
            public int PageCount
            {
                get { return (int)GetValue(PageCountProperty); }
            }


            public static readonly DependencyProperty CountLocalizationProperty
                = DependencyProperty.Register("CountLocalization", typeof(string), _typeofSelf);
            public string CountLocalization
            {
                get { return (string)GetValue(CountLocalizationProperty); }
                set { SetValue(CountLocalizationProperty, value); }
            }

            public static readonly DependencyProperty JumpLocalizationProperty
               = DependencyProperty.Register("JumpLocalization", typeof(string), _typeofSelf);
            public string JumpLocalization
            {
                get { return (string)GetValue(JumpLocalizationProperty); }
                set { SetValue(JumpLocalizationProperty, value); }
            }
            public static readonly DependencyProperty CountProperty
                = DependencyProperty.Register("Count", typeof(int),
                    _typeofSelf, new PropertyMetadata(0, OnCountPropertyChanged, CoerceCount));

            public int Count
            {
                get { return (int)GetValue(CountProperty); }
                set { SetValue(CountProperty, value); }
            }

            private static object CoerceCount(DependencyObject d, object value)
            {
                return Math.Max((int)value, 0);
            }
            private static void OnCountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var control = d as Pagination;
                int newC = (int)e.NewValue;
                control.SetValue(PageCountPropertyKey, (int)Math.Ceiling(newC * 1.0 / control.CountPerPage));
                control.UpdatePagers();
            }


            public static readonly DependencyProperty CountPerPageProperty
                = DependencyProperty.Register("CountPerPage", typeof(int), _typeofSelf,
                    new PropertyMetadata(50, OnCountPerPagePropertyChanged, CoerceCountPerPage));
            public int CountPerPage
            {
                get { return (int)GetValue(CountPerPageProperty); }
                set { SetValue(CountPerPageProperty, value); }
            }
            private static object CoerceCountPerPage(DependencyObject d, object value)
            {
                return Math.Max((int)value, 1);
            }

            private static void OnCountPerPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var control = d as Pagination;
                var countPerPage = (int)e.NewValue;

                if (control._countPerPageTextBox is object)
                    control._countPerPageTextBox.Text = countPerPage.ToString();

                control.SetValue(PageCountPropertyKey, (int)Math.Ceiling(control.Count * 1.0 / countPerPage));

                if (control.Current != 1)
                    control.Current = 1;
                else
                    control.UpdatePagers();
            }

            public static readonly DependencyProperty CurrentProperty
                = DependencyProperty.Register("Current", typeof(int), _typeofSelf,
                    new PropertyMetadata(1, OnCurrentPropertyChanged, CoerceCurrent));
            public int Current
            {
                get { return (int)GetValue(CurrentProperty); }
                set { SetValue(CurrentProperty, value); }
            }
            private static object CoerceCurrent(DependencyObject d, object value)
            {
                var current = (int)value;
                var ctrl = d as Pagination;

                return Math.Max(current, 1);
            }

            private static void OnCurrentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var ctrl = d as Pagination;
                var current = (int)e.NewValue;

                if (ctrl._listBox != null)
                    ctrl._listBox.SelectedItem = current.ToString();

                if (ctrl._jumpPageTextBox != null)
                    ctrl._jumpPageTextBox.Text = current.ToString();

                ctrl.UpdatePagers();
            }
            #endregion

            #region Events
            private void OnCountPerPageTextChanged(object sender, TextChangedEventArgs e)
            {
                if (int.TryParse(_countPerPageTextBox.Text, out int outParsed))
                    CountPerPage = outParsed;
            }
            private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (_listBox.SelectedItem == null)
                    return;

                Current = int.Parse(_listBox.SelectedItem.ToString());
            }
            private void OnJumpPageTextBoxChanged(object sender, TextChangedEventArgs e)
            {
                if (int.TryParse(_jumpPageTextBox.Text, out int _current))
                    Current = _current;
            }
            #endregion

            #region Override
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();


                UnSubscribeEvents();

                _listBox = GetTemplateChild("PART_ListBox") as ListBox;
                _jumpPageTextBox = GetTemplateChild("PART_JumpPageTextBox") as TextBox;
                _countPerPageTextBox = GetTemplateChild("PART_CountPerPageTextBox") as TextBox;

                Init();

                SubscribeEvents();
            }
            #endregion

            #region Private Methods
            private void Init()
            {
                SetValue(PageCountPropertyKey, (int)Math.Ceiling(Count * 1.0 / CountPerPage));


                _jumpPageTextBox.Text = Current.ToString();

                _countPerPageTextBox.Text = CountPerPage.ToString();
                if (_listBox is object)
                    _listBox.SelectedItem = Current.ToString();

            }
            private void UpdatePagers()
            {
                SetValue(PagesPropertyKey, GetPagers(Count, Current));

                if (_listBox != null && _listBox.SelectedItem == null)
                    _listBox.SelectedItem = Current.ToString();
            }
            private IEnumerable<string> GetPagers(int count, int current)
            {
                if (count == 0)
                    return null;

                if (PageCount <= 7)
                    return Enumerable.Range(1, PageCount).Select(p => p.ToString()).ToArray();

                if (current <= 4)
                    return new string[] { "1", "2", "3", "4", "5", Ellipsis, PageCount.ToString() };

                if (current >= PageCount - 3)
                    return new string[] { "1", Ellipsis, (PageCount - 4).ToString(), (PageCount - 3).ToString(), (PageCount - 2).ToString(), (PageCount - 1).ToString(), PageCount.ToString() };

                return new string[] { "1", Ellipsis, (current - 1).ToString(), current.ToString(), (current + 1).ToString(), Ellipsis, PageCount.ToString() };
            }
            private void UnSubscribeEvents()
            {
                if (_listBox is object)
                    _listBox.SelectionChanged -= OnSelectionChanged;
                if (_jumpPageTextBox is object)
                    _jumpPageTextBox.TextChanged -= OnJumpPageTextBoxChanged;
                if (_countPerPageTextBox is object)
                    _countPerPageTextBox.TextChanged -= OnCountPerPageTextChanged;
            }

            private void SubscribeEvents()
            {
                if (_listBox is object)
                    _listBox.SelectionChanged += OnSelectionChanged;
                if (_jumpPageTextBox is object)
                    _jumpPageTextBox.TextChanged += OnJumpPageTextBoxChanged;
                if (_countPerPageTextBox is object)
                    _countPerPageTextBox.TextChanged += OnCountPerPageTextChanged;
            }
            #endregion
        }
    }


