using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JINPUKE
{
    
    public partial class Form1 : Form
    {
        readonly int[] poker = new int[52] { 402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413, 414,
                                          302, 303, 304, 305, 306, 307, 308, 309, 310, 311, 312, 313, 314, 
                                          202, 203, 204, 205, 306, 207, 208, 209, 210, 211, 212, 213, 214,
                                          102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114 };
                                         /* 百位4-黑桃,3-红桃,2-草花,1-方块;十位+个位：2-10对应2-10,11-13对应J-K,14-A */
        readonly string[] pokerSuit = new string[4] { "方块", "草花", "红桃", "黑桃" };
        readonly string[] pokerNum = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取若干个不相同int型随机数
        /// </summary>
        /// <param name="num">要获取的随机数数量</param>
        /// <param name="minValue">随机数区间的最小值</param>
        /// <param name="maxValue">随机数区间的最大值</param>
        /// <returns></returns>
        public int[] getRandomNum(int num, int minValue, int maxValue)         ///////////此处可能存在bug需测试，可能会产生相同随机数！！！
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[num];
            int tmp = 0;
            for (int i = 0; i <= num - 1; i++)
            {
                tmp = ra.Next(minValue, maxValue); //随机取数
                arrNum[i] = getNum(arrNum, tmp, minValue, maxValue, ra); //取出值赋到数组中
            }
            return arrNum;
        }
        public int getNum(int[] arrNum, int tmp, int minValue, int maxValue, Random ra)
        {
            int n = 0;
            while (n <= arrNum.Length - 1)
            {
                if (arrNum[n] == tmp)
                {
                    tmp = ra.Next(minValue, maxValue);
                    getNum(arrNum, tmp, minValue, maxValue, ra);
                }
                n++;
            }
            return tmp;
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            int[] pokerRandom = new int[5];
            
            pokerRandom = getRandomNum(5, 1, 53);

            label1.Text = pokerNameCalculate(poker[pokerRandom[0] - 1]);
            label2.Text = pokerNameCalculate(poker[pokerRandom[1] - 1]);
            label3.Text = pokerNameCalculate(poker[pokerRandom[2] - 1]);
            label4.Text = pokerNameCalculate(poker[pokerRandom[3] - 1]);
            label5.Text = pokerNameCalculate(poker[pokerRandom[4] - 1]);

            label6.Text = poker[pokerRandom[0] - 1].ToString();
            label7.Text = poker[pokerRandom[1] - 1].ToString();
            label8.Text = poker[pokerRandom[2] - 1].ToString();
            label9.Text = poker[pokerRandom[3] - 1].ToString();
            label10.Text = poker[pokerRandom[4] - 1].ToString();


            if((label1.Text == label2.Text) || (label1.Text == label3.Text) || (label1.Text == label4.Text) || (label1.Text == label5.Text))
            {
                btnDeal.Enabled = false;
            }
            else
            {
                if ((label2.Text == label3.Text) || (label2.Text == label4.Text) || (label2.Text == label5.Text))
                {
                    btnDeal.Enabled = false;
                }
                else
                {
                    if ((label3.Text == label4.Text) || (label3.Text == label5.Text))
                    {
                        btnDeal.Enabled = false;
                    }
                    else
                    {
                        if (label4.Text == label5.Text)
                        {
                            btnDeal.Enabled = false;
                        }
                    }
                }
            }
        }
        private string pokerNameCalculate(int pokerCode)
        {
            string pokerName, sPokerNum;
            int _pokerSuit = pokerCode / 100;
            int _pokerNum = pokerCode % 100;
            if (_pokerNum < 14)
            {
                sPokerNum = pokerNum[_pokerNum - 2];  // 2~K
            }
            else
            {
                sPokerNum = pokerNum[12];// A
            }
            pokerName = pokerSuit[_pokerSuit - 1] + sPokerNum;
            return pokerName;
        }

        
    }
}
