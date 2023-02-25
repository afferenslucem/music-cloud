set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    create user music_cloud with password 'masterkey';
    create database music_cloud;
    grant all privileges on database music_cloud to music_cloud;
EOSQL