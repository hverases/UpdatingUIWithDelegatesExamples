using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExample
{
    public partial class Form1 : Form
    {
        private const string PROGRESS_MSG = "Processing item {0} of {1}";
        private const string OPERATION_COMPLETE_TEXT = "Operation complete";

        private BusinessLogic businessLogic;
        private delegate void UpdateUIDelegate(int progress);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetProgress();

            UpdateUIDelegate updateUICallback = new UpdateUIDelegate(UpdateUI);

            this.businessLogic = new BusinessLogic(updateUICallback);
        }


        #region Event Handlers
        private async void btnProcessItems_Click(object sender, EventArgs e)
        {
            int totalItems = (int)numUpDownTotalItems.Value;
            int processingTime = (int)numUpDownProcessingTime.Value;

            SetUIControlsState(false);

            await Task.Run(() => this.businessLogic.ProcessItems(totalItems, processingTime));

            SetUIControlsState(true);
            lblProgress.Text = OPERATION_COMPLETE_TEXT;

            ResetWhenFinished();
        }

        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            DisableButtonIfZero();
        }

        private void numUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            DisableButtonIfZero();
        }
        #endregion


        #region Form methods
        private void SetUIControlsState(bool enabled)
        {
            Application.UseWaitCursor = !enabled;

            numUpDownTotalItems.Enabled = enabled;
            numUpDownProcessingTime.Enabled = enabled;
            btnProcessItems.Enabled = enabled;
        }

        private void DisableButtonIfZero()
        {
            if (numUpDownTotalItems.Value > 0 && numUpDownProcessingTime.Value > 0)
                btnProcessItems.Enabled = true;
            else
                btnProcessItems.Enabled = false;
        }

        private void ResetProgress()
        {
            progressBar.Value = 0;
            lblProgress.Text = "";
        }

        private void ResetWhenFinished()
        {
            new Thread(() => {
                Thread.Sleep(2000);

                if (lblProgress.Text == OPERATION_COMPLETE_TEXT)
                    ResetProgress();
            }).Start();
        }

        private void UpdateUI(int itemNumber)
        {
            int totalItems = (int)numUpDownTotalItems.Value;
            lblProgress.Text = String.Format(PROGRESS_MSG, itemNumber, totalItems);
            int percentage = itemNumber * 100 / totalItems;

            progressBar.Value = percentage;
        }
        #endregion

    }
}
