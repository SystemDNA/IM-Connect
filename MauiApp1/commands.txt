dotnet publish \
  -f:net9.0-ios \
  -c:Release \
  -p:BuildIpa=true \
  -p:CodesignKey="Apple Distribution: Tirumaleswara Reddy Kareddy (34MW9KXL9U)" -p:ArchiveOnBuild=true
