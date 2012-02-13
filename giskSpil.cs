using Gtk;
using System;

public class giskSpil
{
    public static void Main()
    {
        new Vidmot();
    }
}

public class Logik
{
    int tala;
    public Logik() 
    {
        System.Random rand = new System.Random();
        tala = rand.Next(10);
    }

    public int checkNumber(int a)
    {
        return  a.CompareTo(tala);
    }
}

public class Vidmot
{
    Window gluggi;
    HBox hbox1;
    VBox vbox1, vbox2;
    Button button1, button2, button3;
    Label label1, label2;
    Entry entry1;
    Logik logik;
    int tilraunir = 0;
    int gisktala;
    public Vidmot()
    {
        Application.Init();

        gluggi = new Window("Slembitalnaleikur");
        hbox1 = new HBox();
        vbox1 = new VBox();
        vbox2 = new VBox();
        button1 = new Button("Hætta");
        button2 = new Button("Giska");
        button3 = new Button("Nýr leikur");
        label1 = new Label(tilraunir + " tilraunir búnar");
        label2 = new Label("Ég segi til um hvernig þér gengur með töluna.");

        entry1 = new Entry("Giskaðu á mig, ég er milli 0 og 9!");
        logik = new Logik();

        gluggi.Add(hbox1);
        hbox1.Add(vbox1);
        hbox1.Add(vbox2);
        vbox1.Add(label1);
        vbox1.Add(entry1);
        vbox1.Add(button1);
        vbox2.Add(label2);
        vbox2.Add(button2);
        vbox2.Add(button3);

        gluggi.Hidden += onWindowHide;
        button1.Clicked += onWindowHide;
        button2.Clicked += onButton2Clicked;
        button3.Clicked += onButton3Clicked;


        gluggi.ShowAll();

        Application.Run();
    }

    protected void onWindowHide(object source, EventArgs args)
    {
        System.Console.WriteLine("Hide");
        Gtk.Application.Quit();
    }
    protected void onButton2Clicked(object source, EventArgs args)
    {
        System.Console.WriteLine("Giska");
        if(entry1.Text != "")
        {
            try
            {
                gisktala = Convert.ToInt32(entry1.Text);
                System.Console.WriteLine(logik.checkNumber(gisktala));
                tilraunir++;
                label1.Text = tilraunir + " tilraunir búnar";
                checkForVictory();
            } catch( FormatException e) {
                System.Console.WriteLine("Ekki valin tala");
                label2.Text = "Innsláttarreiturinn má bara innihalda tölur!";
            }
        } else {
            System.Console.WriteLine("Engin tala valin");
            label2.Text = "Þú verður að setja tölu í innnsláttarreitinn!";
        }
    }
    protected void onButton3Clicked(object source, EventArgs args)
    {
        System.Console.WriteLine("Nýr leikur");
        logik = new Logik();
        tilraunir = 0;
        label1.Text = tilraunir + " tilraunir búnar";
        label2.Text = "Ég segi til um hvernig þér gengur með töluna.";
        entry1.Text = "Giskaðu á mig, ég er milli 0 og 9!";
    }
    protected void checkForVictory()
    {
        if(logik.checkNumber(gisktala) == 0)
        {
            label2.Text = "Já! " + gisktala + " er rétta talan!";
        } else if(logik.checkNumber(gisktala) == -1) {
            label2.Text = "Nei, talan er hærri en " + gisktala;
        } else {
            label2.Text = "Nei, talan er lægri en " + gisktala;
        }
    }
}
