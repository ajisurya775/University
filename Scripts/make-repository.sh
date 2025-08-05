#!/bin/bash

if [ -z "$1" ]; then
    echo "Usage: ./Scripts/make-repository.sh <Name>"
    exit 1
fi

NAME=$1
PROJECT_NAME=$(basename "$PWD")

TARGET_DIR="Repositories/$NAME"
mkdir -p "$TARGET_DIR"

# File Interface
cat <<EOL > "$TARGET_DIR/I${NAME}Repository.cs"
namespace $PROJECT_NAME.Repositories.$NAME
{
    public interface I${NAME}Repository
    {
        // Tambahkan method sesuai kebutuhan
        Task<IEnumerable<string>> GetAllAsync();
        Task<string> GetByIdAsync(int id);
        Task<bool> AddAsync(string name);
    }
}
EOL

# File Implementation
cat <<EOL > "$TARGET_DIR/${NAME}Repository.cs"
namespace $PROJECT_NAME.Repositories.$NAME
{
    public class ${NAME}Repository : I${NAME}Repository
    {
        public async Task<IEnumerable<string>> GetAllAsync()
        {
            return new List<string> { "RepoSample1", "RepoSample2" };
        }

        public async Task<string> GetByIdAsync(int id)
        {
            return "RepoSampleName";
        }

        public async Task<bool> AddAsync(string name)
        {
            return true;
        }
    }
}
EOL

chmod -R 777 "$TARGET_DIR"
echo "✅ Repository $NAME created in $TARGET_DIR with rwx access"
