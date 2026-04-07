using Project4_EfCodeFirstMovie.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4_EfCodeFirstMovie
{
    public partial class FrmMovies : Form
    {
        public FrmMovies()
        {
            InitializeComponent();
        }

        private void FrmMovies_Load(object sender, EventArgs e)
        {
            using (var db = new Context.MovieContext())
            {
                var categories= db.Categories.ToList();

                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryId";
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            using (var db= new Context.MovieContext())
            {
                var values = db.Movies.Select(x => new
                {
                    ID=x.MovieId,
                    Film=x.MovieTitle,
                    Duration=x.MovieDuration,
                    Category=x.Category.CategoryName,
                    Date=x.MovieReleaseDate,
                    Status=x.MovieStatus,
                    Description=x.MovieDescription
                }).ToList();

                dataGridView1.DataSource = values;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var db=new Context.MovieContext())
            {
                Movie movie = new Movie();
                movie.MovieTitle= txtMovieTitle.Text;
                int duration;
                if (int.TryParse(txtDuration.Text, out duration))
                {
                    movie.MovieDuration = duration;
                }
                else
                {
                    MessageBox.Show("Lütfen süre kısmına sadece sayı giriniz!");
                    return;
                }
                movie.MovieDescription=txtDescription.Text;
                movie.MovieReleaseDate = dateTimePicker1.Value;
                movie.MovieStatus=checkBoxStatus.Checked;

                movie.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());

                db.Movies.Add(movie);
                db.SaveChanges();

                MessageBox.Show("Movie Added");
                btnList.PerformClick();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value?.ToString();
                txtMovieTitle.Text = row.Cells[1].Value?.ToString();
                txtDuration.Text = row.Cells[2].Value?.ToString();

                cmbCategory.Text = row.Cells[3].Value?.ToString();

                if (row.Cells[4].Value != null)
                {
                    dateTimePicker1.Value = (DateTime)row.Cells[4].Value;
                }

                if (row.Cells[5].Value != null)
                {
                    checkBoxStatus.Checked = (bool)row.Cells[5].Value;
                }

                txtDescription.Text = row.Cells[6].Value?.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select a movie from the list before deleting.");

                DialogResult result = MessageBox.Show("Are you sure deleting this movie?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (var db = new Context.MovieContext())
                    {
                        int id = int.Parse(txtId.Text);
                        var value = db.Movies.Find(id);

                        if (value != null)
                        {
                            db.Movies.Remove(value);
                            db.SaveChanges();
                            MessageBox.Show("Movie Deleted");
                            btnList.PerformClick();

                        }
                        else
                        {
                            MessageBox.Show("Movie not found.");
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select a movie to update.");
                return;
            }

            using (var db=new Context.MovieContext())
            {
                int id=int.Parse(txtId.Text);
                var movie= db.Movies.Find(id);

                if(movie != null)
                {
                    movie.MovieTitle = txtMovieTitle.Text;
                    movie.MovieDescription = txtDescription.Text;
                    movie.MovieDuration = int.Parse(txtDuration.Text);
                    movie.MovieReleaseDate= dateTimePicker1.Value;
                    movie.MovieStatus = checkBoxStatus.Checked;
                    movie.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());

                    db.SaveChanges();
                    MessageBox.Show("Movie Updated");
                    btnList.PerformClick();
                }
            }
        }
    }
}
