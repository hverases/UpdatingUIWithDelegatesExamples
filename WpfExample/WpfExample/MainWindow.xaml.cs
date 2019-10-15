using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit;

namespace WpfExample
{
    public partial class MainWindow : Window
    {
        private const string PROGRESS_MSG = "Processing item {0} of {1}";
        private const string OPERATION_COMPLETE_TEXT = "Operation complete";

        private BusinessLogic businessLogic;
        private delegate void UpdateUIDelegate(int progress);

        Dispatcher dispatcherUI;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Event handlers are binded manually here to avoid firing events when setting default values
            numUpDownTotalItems.ValueChanged += NumUpDown_ValueChanged;
            numUpDownProcessingTime.ValueChanged += NumUpDown_ValueChanged;

            dispatcherUI = numUpDownTotalItems.Dispatcher;

            ResetProgress();

            UpdateUIDelegate updateUICallback = new UpdateUIDelegate(UpdateUI);

            this.businessLogic = new BusinessLogic(updateUICallback);
        }


        #region Event Handlers
        private async void BtnProcessItems_Click(object sender, RoutedEventArgs e)
        {
            int totalItems = numUpDownTotalItems.Value.Value;
            int processingTime = numUpDownProcessingTime.Value.Value;

            SetUIControlsState(false);

            await Task.Run(() => this.businessLogic.ProcessItems(totalItems, processingTime));

            SetUIControlsState(true);
            lblProgress.Content = OPERATION_COMPLETE_TEXT;

            ResetWhenFinished();
        }

        private void NumUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            if (IsValueNullOrZero(numUpDownTotalItems) || IsValueNullOrZero(numUpDownProcessingTime))
                btnProcessItems.IsEnabled = false;
            else
                btnProcessItems.IsEnabled = true;
        }
        #endregion


        #region Window methods
        private void SetUIControlsState(bool enabled)
        {
            Mouse.OverrideCursor = enabled ? Cursors.Arrow : Cursors.Wait;

            numUpDownTotalItems.IsEnabled = enabled;
            numUpDownProcessingTime.IsEnabled = enabled;
            btnProcessItems.IsEnabled = enabled;
        }

        private void ResetProgress()
        {
            progressBar.Value = 0;
            lblProgress.Content = "";
        }

        private void ResetWhenFinished()
        {
            new Thread(() => {
                Thread.Sleep(2000);

                dispatcherUI.BeginInvoke(new Action(() => {
                    if (lblProgress.Content.ToString() == OPERATION_COMPLETE_TEXT)
                        ResetProgress();
                }));
            }).Start();
        }

        private void UpdateUI(int itemNumber)
        {

            dispatcherUI.BeginInvoke(new Action(() => {
                int totalItems = numUpDownTotalItems.Value.Value;
                lblProgress.Content = String.Format(PROGRESS_MSG, itemNumber, totalItems);
                int percentage = itemNumber * 100 / totalItems;

                progressBar.Value = percentage;
            }));

        }

        private bool IsValueNullOrZero(IntegerUpDown upDownControl)
        {
            return !upDownControl.Value.HasValue || upDownControl.Value.Value == 0;
        }
        #endregion

    }
}
