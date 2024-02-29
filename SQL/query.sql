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

--- Comments

CREATE TABLE Comment (
  id SERIAL PRIMARY KEY,
  content TEXT NOT NULL,
  user_id INTEGER NOT NULL REFERENCES users(user_id),
  created_at TIMESTAMP NOT NULL DEFAULT (NOW())
);