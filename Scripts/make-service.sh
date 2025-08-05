#!/bin/bash

if [ -z "$1" ]; then
    echo "Usage: ./Scripts/make-service.sh <Name>"
    exit 1
fi

NAME=$1
PROJECT_NAME=$(basename "$PWD")

TARGET_DIR="Services/$NAME"
mkdir -p "$TARGET_DIR"

# File Interface
cat <<EOL > "$TARGET_DIR/I${NAME}Service.cs"
namespace $PROJECT_NAME.Services.$NAME
{
    public interface I${NAME}Service
    {
        // Tambahkan method yang dibutuhkan
        Task<IEnumerable<string>> GetAllAsync();
        Task<string> GetByIdAsync(int id);
        Task<bool> CreateAsync(string name);
    }
}
EOL

# File Implementation
cat <<EOL > "$TARGET_DIR/${NAME}Service.cs"
namespace $PROJECT_NAME.Services.$NAME
{
    public class ${NAME}Service : I${NAME}Service
    {
        public async Task<IEnumerable<string>> GetAllAsync()
        {
            return new List<string> { "Sample1", "Sample2" };
        }

        public async Task<string> GetByIdAsync(int id)
        {
            return "SampleName";
        }

        public async Task<bool> CreateAsync(string name)
        {
            return true;
        }
    }
}
EOL

chmod -R 777 "$TARGET_DIR"
echo "✅ Service $NAME created in $TARGET_DIR with rwx access"
