using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelWorks_Worker.View
{
    public partial class SelectableButtonUserControl : UserControl
    {
        private string text_;
        private bool requireComment_;
        private PopupView view_;
        private PopupSelectionType type_;

        public void InitButton(PopupView view, PopupSelectionType type, string text, bool requireComment = false) {
            text_ = text;
            view_ = view;
            type_ = type;
            requireComment_ = requireComment;

            button1.Text = text;
        }

        public SelectableButtonUserControl() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (type_ == PopupSelectionType.Place) {
                view_.OnSelectedPlace(text_);
            } else if (type_ == PopupSelectionType.Mark) {
                view_.OnSelectedMark(text_, requireComment_);
            } else if (type_ == PopupSelectionType.Employee) {
                view_.OnSelectedEmployee(text_);
            }
        }
    }
}
