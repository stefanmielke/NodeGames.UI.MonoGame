ApiKey=$1
Source=$2
Version=$3

nuget pack ./NodeGames.UI.MonoGame.nuspec -Verbosity detailed -Version $Version

nuget push ./NodeGames.UI.MonoGame.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source