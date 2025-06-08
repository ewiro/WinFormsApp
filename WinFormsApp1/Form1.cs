namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static double GetE2()
        {
            double a = 6378137, f = 1 / 298.25722;
            double e2 = 2 * f - f * f;
            return e2;
        }

        private static double GetN(double B)
        {
            double a = 6378137;
            double e2 = GetE2();
            double sinB = Math.Sin(B);
            double N = a / Math.Sqrt(1 - e2 * sinB * sinB);
            return N;
        }

        private static void XYZ2BLH(double X, double Y, double Z, out double B, out double L, out double H)
        {
            double e2 = GetE2();
            double a = 6378137;
            double tempB = Math.Atan2(Z, Math.Sqrt(X * X + Y * Y));
            double N = GetN(tempB);
            B = tempB;
            double b = a * (1 - 1 / 298.25722);
            double e2_ = (a * a - b * b) / (b * b);
            double theta = Math.Atan(Z * a / (Math.Sqrt(X * X + Y * Y) * b));
            L = Math.Atan2(Y, X);
            double p = Math.Sqrt(X * X + Y * Y);
            theta = Math.Atan2(Z * a, p * b);
            B = Math.Atan2(Z + e2_ * b * Math.Pow(Math.Sin(theta), 3), p - e2 * a * Math.Pow(Math.Cos(theta), 3));
            H = Math.Sqrt(X * X + Y * Y) / Math.Cos(B) - N;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double X = Convert.ToSingle(textBox1.Text);
            double Y = Convert.ToSingle(textBox2.Text);
            double Z = Convert.ToSingle(textBox3.Text);
            double B, L, H;
            XYZ2BLH(X, Y, Z, out B, out L, out H);
            textBox4.Text = Convert.ToString(B);
            textBox5.Text = Convert.ToString(L);
            textBox6.Text = Convert.ToString(H);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
        }
    }
}
