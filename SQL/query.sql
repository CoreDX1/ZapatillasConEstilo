--- PostgreSQL

--- Registration and Login

CREATE TABLE users (
  user_id SERIAL,
  user_name VARCHAR(255) NOT NULL,
  last_name VARCHAR(255) NOT NULL,
  phone_number VARCHAR(255) NOT NULL,
  email_address VARCHAR(255) NOT NULL UNIQUE,
  password_hash BYTEA NOT NULL, -- Hashed password using a strong algorithm
  password_salt VARCHAR(512) NOT NULL, -- Randomly generated salt for password hashing
  role VARCHAR(255) NOT NULL DEFAULT 'user',
  created_at TIMESTAMP NOT NULL DEFAULT (NOW()),
  updated_at TIMESTAMP,
  CHECK (role IN ('user', 'admin', 'moderator')), -- Enforce valid role values
  PRIMARY KEY (user_id)
);

CREATE TABLE Session (
  id SERIAL PRIMARY KEY,
  user_id INTEGER REFERENCES User(id) ON DELETE CASCADE,
  token VARCHAR(255) NOT NULL UNIQUE,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
)

--- Comments

CREATE TABLE Post (
  id SERIAL PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  content TEXT NOT NULL,
  user_id INTEGER REFERENCES User(id) ON DELETE CASCADE,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Comment (
  id SERIAL PRIMARY KEY,
  content TEXT NOT NULL,
  user_id INTEGER REFERENCES User(id) ON DELETE CASCADE,
  post_id INTEGER REFERENCES Post(id) ON DELETE CASCADE,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);