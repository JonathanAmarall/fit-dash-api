using FitDash.Workout.Domain.Repositories;
using FitDash.Workout.Entities;

namespace FitDash.Workout.Data.Seeders
{
    public static class ExerciseSeed
    {
        public static void CreateIfNotExist(IExerciseRepository repository)
        {
            var exerciseList = new List<Exercise>();

            exerciseList.Add(new Exercise("Supino Reto Barra", "https://youtu.be/sqOw2Y6uDWQ"));
            exerciseList.Add(new Exercise("Supino Reto Halteres", "https://youtu.be/Spbmm66NsuY"));
            exerciseList.Add(new Exercise("Supino Reto Smith", "https://youtu.be/b-THwNtIYxY"));
            exerciseList.Add(new Exercise("Supino Inclinado Barra", "https://youtu.be/lBCjPgnIzKk"));
            exerciseList.Add(new Exercise("Supino Inclinado Halteres", "https://youtu.be/Z1rCZ0YHrP0"));
            exerciseList.Add(new Exercise("Supino Inclinado Smith", "https://youtu.be/L4kIk2gMeBw"));
            exerciseList.Add(new Exercise("Supino Declinado Barra", "https://youtu.be/hZ9woVlzGdA"));
            exerciseList.Add(new Exercise("Supino Declinado Halteres", "https://youtu.be/0SFB2chQTPY"));
            exerciseList.Add(new Exercise("Supino Declinado Smith", "https://youtu.be/xLQ9ZbH9ljc"));
            exerciseList.Add(new Exercise("Crucifixo Reto Halteres", "https://youtu.be/dQi36EfA88c"));
            exerciseList.Add(new Exercise("Crucifixo Inclinado Halteres", "https://youtu.be/4JvT5Ys1Bog"));
            exerciseList.Add(new Exercise("Crucifixo Declinado Halteres", "https://youtu.be/QsZ8VYaRh34"));
            exerciseList.Add(new Exercise("Over Polia Alta", "https://youtu.be/HNUji0rHFCs"));
            exerciseList.Add(new Exercise("Over Polia Média", "https://youtu.be/iLRFLm82dbg"));
            exerciseList.Add(new Exercise("Over Polia Baixa", "https://youtu.be/Jy_hZnK"));
            exerciseList.Add(new Exercise("Flexão De Braço", "https://youtu.be/F9FC_KBsLpY"));
            exerciseList.Add(new Exercise("Crucifixo Na Máquina", "https://youtu.be/Ru9OVOUlp0U"));


            foreach (var exercise in exerciseList)
            {
                if(!repository.Exist(exercise.Name))
                {
                    repository.CreateAsync(exercise).Wait();
                }
            }

            repository.UnitOfWork.Commit().Wait();
        }
    }
}
