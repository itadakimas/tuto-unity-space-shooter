using UnityEditor;

public class BuildManager
{
  private static BuildPlayerOptions CreatePlayerOptions(BuildTarget target)
  {
    BuildPlayerOptions options = new BuildPlayerOptions();

    string buildsDirectory = "Builds/";

    options.options = BuildOptions.None;
    options.target = target;
    options.locationPathName = buildsDirectory + target;
    return options;
  }

  public static void BuildIos()
  {
    BuildPipeline.BuildPlayer(CreatePlayerOptions(BuildTarget.iOS));
  }

  public static void BuildAndroid()
  {
    BuildPipeline.BuildPlayer(CreatePlayerOptions(BuildTarget.Android));
  }
}
