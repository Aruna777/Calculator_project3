using System.Net.Http.Json;
using MathsExercise.Library;

namespace MathsExercise;

public partial class MainPage : ContentPage
{
    private HttpClient httpClient;
    private Uri uri;
    public int id = 0;
    public int correctIndex = -1;

    public MainPage()
	{
		InitializeComponent();
        this.Run();
    }

    private void Run()
    {
        // this.uri = new Uri("https://localhost:7169/exercise");
        this.uri = new Uri("https://1e61-2600-8803-7696-2400-d9a5-5f73-cd76-7c.ngrok.io/exercise");
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        {
            if (cert.Issuer.Equals("CN=localhost"))
                return true;
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
        this.httpClient = new HttpClient(handler);
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await this.Get();
    }

    private async Task Get()
    {
        try
        {
            this.id = this.id + 1;
            var message = new HttpRequestMessage(HttpMethod.Post, this.uri);
            message.Content = JsonContent.Create(new
            {
                id = this.id
            });
            HttpResponseMessage response = await httpClient.SendAsync(message);
            var data = await response.Content.ReadFromJsonAsync<Response>();
            var exercise = data.Data;
            this.Exercise.Text = exercise.ToCalculator + " = ?";
            this.TokenOne.Text = exercise.Tokens[0].ToString();
            this.TokenTwo.Text = exercise.Tokens[1].ToString();
            this.TokenThree.Text = exercise.Tokens[2].ToString();
            this.TokenFour.Text = exercise.Tokens[3].ToString();
            this.Solution.Text = "---";
            this.ClearAllButtons();
            this.Retry.IsVisible = false;
            this.correctIndex = exercise.CorrectIndex;
        }catch(Exception ex)
        {
            var hello = ex.Message;
        }
    }

    private void ClearButton(Button button)
    {
        button.BackgroundColor = Color.FromHex("#012FAE");
    }

    private void ClearAllButtons()
    {
        this.ClearButton(this.TokenOne);
        this.ClearButton(this.TokenTwo);
        this.ClearButton(this.TokenThree);
        this.ClearButton(this.TokenFour);
    }

    private async Task MoveToNextExercise()
    {
        await Task.Delay(2000);
        await this.Get();
    }

    private void TryAgain(object sender, EventArgs e)
    {
        this.ClearAllButtons();
        this.Retry.IsVisible = false;
        this.Solution.Text = "---";
    }

    public void TokenOneClicked(object sender, EventArgs e)
    {
        if (this.Solution.Text == "---")
        {
            this.ClearAllButtons();
            this.TokenOne.BackgroundColor = Colors.Orange;
            if (this.correctIndex == 0)
            {
                this.Solution.Text = "Correct Answer";
                this.MoveToNextExercise();
            } else
            {
                this.Retry.IsVisible = true;
                this.Solution.Text = "Wrong Answer";
            }
        }
    }

    public void TokenTwoClicked(object sender, EventArgs e)
    {
        if (this.Solution.Text == "---")
        {
            this.ClearAllButtons();
            this.TokenTwo.BackgroundColor = Colors.Orange;
            if (this.correctIndex == 1)
            {
                this.Solution.Text = "Correct Answer";
                this.MoveToNextExercise();
            }
            else
            {
                this.Retry.IsVisible = true;
                this.Solution.Text = "Wrong Answer";
            }
        }
    }

    public void TokenThreeClicked(object sender, EventArgs e)
    {
        if (this.Solution.Text == "---")
        {
            this.ClearAllButtons();
            this.TokenThree.BackgroundColor = Colors.Orange;
            if (this.correctIndex == 2)
            {
                this.Solution.Text = "Correct Answer";
                this.MoveToNextExercise();
            }
            else
            {
                this.Retry.IsVisible = true;
                this.Solution.Text = "Wrong Answer";
            }
        }
    }

    public void TokenFourClicked(object sender, EventArgs e)
    {
        if (this.Solution.Text == "---")
        {
            this.ClearAllButtons();
            this.TokenFour.BackgroundColor = Colors.Orange;
            if (this.correctIndex == 3)
            {
                this.Solution.Text = "Correct Answer";
                this.MoveToNextExercise();
            }
            else
            {
                this.Retry.IsVisible = true;
                this.Solution.Text = "Wrong Answer";
            }
        }
    }
}


