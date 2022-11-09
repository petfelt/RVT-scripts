
declare global.number[0] with network priority low
declare global.number[1] with network priority local
declare global.number[2] with network priority local
declare global.number[3] with network priority local
declare global.number[4] with network priority local
declare global.number[5] with network priority local
declare global.number[6] with network priority local
declare global.number[7] with network priority low
declare global.number[8] with network priority local
declare global.number[9] with network priority local
declare global.number[10] with network priority low
declare global.number[11] with network priority low
declare global.object[0] with network priority low
declare global.object[1] with network priority local
declare global.object[2] with network priority local
declare global.object[3] with network priority low
declare global.object[4] with network priority low
declare global.object[5] with network priority low
declare global.object[6] with network priority low
declare global.object[7] with network priority low
declare global.object[8] with network priority low
declare global.object[9] with network priority local
declare global.object[10] with network priority low
declare global.object[11] with network priority low
declare global.object[12] with network priority local
declare global.object[13] with network priority low
declare global.object[14] with network priority local
declare global.object[15] with network priority low
declare global.player[0] with network priority local
declare global.player[1] with network priority local
declare global.player[2] with network priority local
declare global.player[3] with network priority local
declare global.team[0] with network priority low
declare global.team[1] with network priority low
declare global.team[2] with network priority low
declare global.team[3] with network priority low
declare global.team[4] with network priority low
declare global.team[5] with network priority low
declare global.team[6] with network priority low
declare global.team[7] with network priority low
declare global.timer[0] = script_option[3]
declare global.timer[1] = 10
declare global.timer[2] = 12
declare player.number[0] with network priority low
declare player.number[1] with network priority low
declare player.number[2] with network priority low = 1
declare player.number[3] with network priority low
declare player.number[4] with network priority low
declare player.number[5] with network priority local
declare player.number[6] with network priority local
declare player.timer[0] = 1
declare player.timer[1] = 5
declare player.timer[2] = 1
declare player.timer[3] = 5
declare player.object[0] with network priority local
declare player.object[1] with network priority local
declare player.object[2] with network priority local
declare player.object[3] with network priority local
declare player.player[0] with network priority low
declare object.number[0] with network priority low
declare object.number[1] with network priority local
declare object.number[2] with network priority local
declare object.number[3] with network priority low
declare object.number[4] with network priority low
declare object.number[5] with network priority low
declare object.number[6] with network priority low
declare object.number[7] with network priority low
declare object.object[0] with network priority low
declare object.object[1] with network priority local
declare object.object[2] with network priority low
declare object.object[3] with network priority local
declare object.timer[0] = script_option[3]
declare object.timer[2] = 3

on init: do
   for each object with label "dc_checkpoint" do
      current_object.number[0] = current_object.spawn_sequence
      current_object.team = team[0]
      current_object.set_waypoint_icon(diamond)
      current_object.set_waypoint_text("%nm", hud_player.number[5])
      current_object.set_waypoint_priority(high)
      current_object.set_invincibility(1)
      current_object.set_spawn_location_permissions(no_one)
      current_object.set_waypoint_visibility(no_one)
      current_object.set_shape_visibility(no_one)
   end
end

on double host migration: do
   for each object with label "dc_checkpoint" do
      current_object.number[0] = current_object.spawn_sequence
   end
   for each player do
      current_player.player[0] = current_player
   end
end

function trigger_0()
   current_object.detach()
   if current_object.number[1] == 0 then 
      current_object.number[1] = current_object.spawn_sequence
      if current_object.spawn_sequence < -10 then 
         current_object.number[1] += 101
         current_object.number[1] *= 2
         if current_object.spawn_sequence > -71 then 
            current_object.number[1] *= 2
            if current_object.spawn_sequence > -41 then 
               current_object.number[1] *= 3
               current_object.number[1] /= 2
            end
         end
      end
      current_object.number[1] *= 10
      current_object.number[1] += 100
      if current_object.spawn_sequence < -10 then 
         current_object.number[1] += 1000
         if current_object.spawn_sequence > -71 then 
            current_object.number[1] += -600
            if current_object.spawn_sequence > -41 then 
               current_object.number[1] += -1200
            end
         end
      end
      if current_object.spawn_sequence == -10 then 
         current_object.number[1] = 1
      end
      current_object.set_scale(current_object.number[1])
      current_object.copy_rotation_from(current_object, false)
      if current_object.object[2] != no_object then 
         current_object.copy_rotation_from(current_object, true)
         current_object.attach_to(current_object.object[2], 0, 0, 0, relative)
      end
      current_object.number[2] = 1
   end
end

do
   global.number[2] = 1
   global.timer[2].set_rate(-100%)
end

for each object with label "dc_checkpoint" do
   current_object.set_shape_visibility(no_one)
   for each player do
      if current_object.number[0] == current_player.number[4] and current_player.number[0] == 0 then 
         current_object.set_shape_visibility(mod_player, current_player, 1)
      end
   end
end

for each player do
   if current_player.number[0] != 1 then 
      if current_player.is_elite() then 
         current_player.set_loadout_palette(elite_tier_1)
      end
      if not current_player.is_elite() then 
         current_player.set_loadout_palette(spartan_tier_1)
      end
   end
   if current_player.number[0] == 1 then 
      if current_player.is_elite() then 
         current_player.set_loadout_palette(elite_tier_2)
      end
      if not current_player.is_elite() then 
         current_player.set_loadout_palette(spartan_tier_2)
      end
   end
end

do
   global.number[3] = 0
   global.number[4] = -1
   for each player do
      global.number[4] += 1
      if current_player.number[0] == 1 then 
         global.number[3] += 1
      end
   end
   for each player randomly do
      if global.number[3] < script_option[0] and global.number[3] < global.number[4] and current_player.number[1] != 1 and current_player.number[0] != 1 then 
         current_player.number[0] = 1
         global.number[3] += 1
      end
   end
   for each player do
      if current_player.number[0] == 1 and current_player.team != team[1] then 
         send_incident(inf_new_zombie, current_player, no_player)
         current_player.team = team[1]
         current_player.apply_traits(script_traits[0])
         current_player.biped.kill(true)
      end
   end
end

for each player do
   script_widget[0].set_text("Safe Haven - %s", global.timer[0])
   script_widget[1].set_text("%n\% turret damage zone", hud_player.number[6])
   script_widget[0].set_visibility(current_player, false)
   script_widget[1].set_visibility(current_player, false)
end

for each player do
   current_player.timer[1].set_rate(-100%)
   for each player do
      if current_player.team == team[0] then 
         current_player.set_round_card_title("Race through the checkpoints!\n\nAvoid the zombie grenade barrage!")
      end
   end
   for each player do
      if current_player.team == team[1] then 
         current_player.set_round_card_title("Braaaaaains...")
      end
   end
end

for each player do
   if current_player.number[3] == 0 and current_player.timer[1].is_zero() then 
      send_incident(infection_game_start, current_player, no_player)
      game.show_message_to(current_player, none, "Created by mini nt - v0.97       (Anvil V1.05a)")
      game.show_message_to(current_player, none, "Depth Chargers")
      current_player.number[3] = 1
   end
end

for each player do
   current_player.team = team[0]
   if current_player.number[0] == 1 then 
      current_player.team = team[1]
      current_player.apply_traits(script_traits[0])
   end
   if current_player.number[0] == 0 then
      current_player.apply_traits(script_traits[3])
      current_player.biped.set_waypoint_icon(bullseye)
   end
end

for each player do
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) then 
      current_player.number[1] = 0
      global.player[0] = current_player
      global.player[1] = no_player
      global.player[1] = current_player.try_get_killer()
      if current_player.killer_type_is(kill) and global.player[0].number[0] == 1 and global.player[0].number[0] != global.player[1].number[0] then 
         global.player[1].score += script_option[7]
         send_incident(zombie_kill_kill, global.player[1], global.player[0])
      end
      if current_player.killer_type_is(kill) and script_option[2] == 1 and global.player[0].number[0] == 1 and global.player[0].number[0] != global.player[1].number[0] and global.player[1].number[2] == 1 then 
         global.player[1].score += script_option[6]
      end
      if current_player.killer_type_is(kill) and not global.player[1] == no_player and global.player[0].number[0] == 0 then 
         global.player[0].number[0] = 1
         send_incident(inf_new_infection, global.player[1], global.player[0])
         send_incident(infection_kill, global.player[1], global.player[0])
         global.player[1].score += script_option[10]
         global.player[1].script_stat[1] += 1
      end
      if current_player.killer_type_is(suicide) then 
         global.player[1].score += script_option[8]
         global.player[0].number[0] = 1
      end
      if current_player.killer_type_is(betrayal) and global.player[0].number[0] == global.player[1].number[0] then 
         global.player[1].score += script_option[9]
      end
   end
end

if script_option[2] == 1 and global.object[0] == no_object then 
   global.object[0] = get_random_object("inf_haven", global.object[1])
   if global.number[1] == 1 then 
      send_incident(hill_moved, all_players, all_players)
   end
   global.number[1] = 1
end

if script_option[2] == 1 and global.timer[0].is_zero() then 
   global.timer[0].set_rate(0%)
   global.timer[0] = script_option[3]
   global.object[0].set_waypoint_visibility(no_one)
   global.object[0].set_shape_visibility(no_one)
   global.object[0].set_waypoint_timer(none)
   global.object[0].number[0] = 0
   global.object[1] = global.object[0]
   global.object[0] = no_object
   global.object[0] = get_random_object("inf_haven", global.object[1])
end

do
   global.object[0].set_waypoint_visibility(everyone)
   global.object[0].set_waypoint_icon(crown)
   global.object[0].set_shape_visibility(everyone)
   global.object[0].set_waypoint_priority(high)
end

if script_option[2] == 1 then 
   for each player do
      if global.object[0].shape_contains(current_player.biped) and current_player.number[0] == 0 and global.object[0].number[0] == 0 then 
         global.timer[0].set_rate(-100%)
         global.object[0].number[0] = 1
      end
   end
   if global.object[0].number[0] == 1 then 
      global.object[0].timer[0] = global.timer[0]
      global.object[0].set_waypoint_timer(0)
      if global.object[0].timer[0] < 6 then 
         global.object[0].set_waypoint_priority(blink)
      end
   end
end

if script_option[1] == 1 then 
   global.number[3] = 0
   if global.number[0] == 0 then 
      for each player do
         if not current_player.number[0] == 1 then 
            global.number[3] += 1
         end
      end
      if global.number[3] == 1 then 
         for each player do
            if not current_player.number[0] == 1 then 
               current_player.apply_traits(script_traits[1])
               current_player.biped.set_waypoint_icon(skull)
               current_player.biped.set_waypoint_priority(high)
               current_player.number[1] = 1
               current_player.score += script_option[11]
               send_incident(inf_last_man, current_player, all_players)
            end
         end
         global.number[0] = 1
      end
   end
end


for each player do
   if current_player.biped != no_object then 
      global.object[8] = current_player.try_get_weapon(primary)
      global.object[9] = current_player.try_get_armor_ability()
      for each object with label 0 do
         if not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(particle_emitter_fire) and not current_object.is_of_type(magnum) and global.object[8] != current_object and global.object[9] != current_object then 
            global.player[3] = current_object.try_get_carrier()
            if global.player[3] == no_player then 
               global.number[9] = current_object.get_distance_to(current_player.biped)
               if global.number[9] < 19 then 
                  global.number[9] = current_object.get_speed()
                  if global.number[9] > 70 then 
                     current_object.set_waypoint_priority(low)
                     current_object.set_waypoint_icon(skull)
                     current_object.team = current_player.team
                     current_object.set_waypoint_visibility(enemies)
                     current_object.set_waypoint_visibility(mod_player, current_player, 1)
                  end
               end
            end
         end
      end
   end
end

for each player do
   if current_player.number[1] == 1 then 
      current_player.apply_traits(script_traits[1])
   end
end

for each player do
   script_widget[0].set_visibility(current_player, false)
   current_player.number[2] = 0
   if script_option[2] == 1 and global.object[0].shape_contains(current_player.biped) and current_player.number[0] == 0 then 
      current_player.number[2] = 1
      current_player.apply_traits(script_traits[2])
      script_widget[0].set_visibility(current_player, true)
   end
end


for each player do
   script_widget[1].set_visibility(current_player, false)
end


for each object with label "dc_zone" do
   for each player do
      if current_object.shape_contains(current_player.biped) then
         global.object[9] = current_player.try_get_vehicle()
         script_widget[1].set_visibility(current_player, true)
         if current_object.spawn_sequence <= 4 then
            current_player.number[6] = 25
            if global.object[9] != no_object then
               current_player.apply_traits(script_traits[4])
            end
         end
         if current_object.spawn_sequence == 5 then
            current_player.number[6] = 50
            if global.object[9] != no_object then
               current_player.apply_traits(script_traits[5])
            end
         end
         if current_object.spawn_sequence == 6 then
            current_player.number[6] = 75
            if global.object[9] != no_object then
               current_player.apply_traits(script_traits[6])
            end
         end
         if current_object.spawn_sequence == 7 then
            current_player.number[6] = 100
            if global.object[9] != no_object then
               current_player.apply_traits(script_traits[7])
            end
         end
      end
      if current_object.spawn_sequence >= 8 then
         if global.timer[1].is_zero() then
            current_object.set_shape_visibility(allies)
         end
         script_widget[1].set_visibility(current_player, false)
      end
   end
end

for each object with label "dc_marker" do
   current_object.set_waypoint_visibility(allies)
   if current_object.spawn_sequence == 0 then
      current_object.set_waypoint_text("ARTILLERY")
   end
   if current_object.spawn_sequence == 1 then
      current_object.set_waypoint_range(0, 100)
      current_object.set_waypoint_text("HANDHELD")
   end
   if current_object.spawn_sequence == 2 then
      current_object.set_waypoint_range(0, 100)
      current_object.set_waypoint_text("CLOSE RANGE")
   end
end

do
   global.timer[1].set_rate(-100%)
   if global.timer[1].is_zero() then 
      global.number[3] = 0
      for each player do
         if current_player.number[0] == 0 then 
            global.number[3] += 1
         end
      end
      for each player do
         if global.number[3] == 1 and current_player.number[0] == 0 and current_player.killer_type_is(suicide) then 
            global.number[3] = 0
         end
      end
      if global.number[3] == 0 then 
         send_incident(infection_zombie_win, all_players, all_players)
         for each player do
            if current_player.number[1] != 1 and current_player.number[0] == 1 then 
               current_player.score += script_option[4]
            end
         end
         game.end_round()
      end
   end
end

if game.round_timer.is_zero() and game.round_time_limit > 0 then 
   global.number[3] = 0
   for each player do
      if current_player.number[0] == 0 then 
         global.number[3] += 1
      end
   end
   if not global.number[3] == 0 then 
      send_incident(infection_survivor_win, all_players, all_players)
      for each player do
         if current_player.number[0] == 0 then 
            current_player.score += script_option[5]
         end
      end
      game.end_round()
   end
end

for each player do
   if current_player.number[0] == 0 then 
      current_player.timer[2].set_rate(-100%)
      if current_player.timer[2].is_zero() then 
         current_player.script_stat[0] += 1
         current_player.timer[2].reset()
      end
   end
end

for each object do
   if not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) and current_object.team == team[7] then 
      current_object.set_invincibility(1)
   end
end

for each player do
   if script_option[12] == 1 then 
      if current_player.number[0] != 1 then 
         current_player.set_co_op_spawning(true)
      end
      if current_player.number[0] == 1 then 
         current_player.set_co_op_spawning(false)
      end
   end
   if script_option[12] == 2 then 
      if current_player.number[0] != 1 then 
         current_player.set_co_op_spawning(false)
      end
      if current_player.number[0] == 1 then 
         current_player.set_co_op_spawning(true)
      end
   end
   if script_option[12] == 3 then 
      current_player.set_co_op_spawning(true)
   end
end

for each object with label "scale" do
   if current_object.number[2] == 0 then 
      if current_object.team == team[2] then 
         current_object.object[2] = current_object.place_at_me(heavy_barrier, none, never_garbage_collect, 0, 0, 0, none)
         if current_object.object[2] == no_object then 
            current_object.object[2] = current_object.place_at_me(warthog_turret, none, never_garbage_collect, 0, 0, 0, none)
         end
      end
      if current_object.team == team[3] then 
         current_object.object[2] = current_object.place_at_me(monitor, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.object[2] != no_object then 
         current_object.object[2].set_invincibility(1)
         current_object.object[2].set_scale(50)
         current_object.object[2].attach_to(current_object, 0, 0, 0, relative)
         current_object.object[2].detach()
         current_object.object[2].copy_rotation_from(current_object, false)
         current_object.attach_to(current_object.object[2], 0, 0, 0, relative)
      end
      trigger_0()
   end
end

for each object with label "attach_base" do
   if current_object.spawn_sequence != 0 then 
      global.object[5] = no_object
      global.object[5] = current_object
      global.number[8] = current_object.spawn_sequence
      global.number[8] *= -1
      for each object with label "attachment" do
         if current_object.spawn_sequence != 0 and global.object[5].spawn_sequence == current_object.spawn_sequence or global.number[8] == current_object.spawn_sequence and current_object.number[1] == 0 then 
            if current_object.spawn_sequence < 0 then 
               global.object[6] = current_object
               for each object do
                  global.number[7] = current_object.get_distance_to(global.object[6])
                  global.player[3] = current_object.try_get_carrier()
                  if global.number[7] == 0 and global.player[3] == no_player and global.object[6] != current_object and not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) then 
                     current_object.detach()
                     current_object.attach_to(global.object[5], 0, 0, 5, relative)
                     if current_object.is_of_type(warthog_turret_rocket) or current_object.is_of_type(warthog_turret_gauss) or current_object.is_of_type(warthog_turret) or current_object.is_of_type(shade_gun_plasma) then 
                        current_object.object[0] = current_object.place_at_me(flag_stand, none, none, 0, 0, 0, none)
                        current_object.object[0].set_scale(1)
                        current_object.detach()
                        current_object.attach_to(current_object.object[0], 0, 0, 0, relative)
                        current_object.object[0].attach_to(global.object[5], 0, 0, 5, relative)
                        global.object[5].object[0] = current_object
                        current_object.object[0].set_shape(box, 5, 5, 10, 0)
                     end
                  end
               end
               current_object.attach_to(global.object[5], 0, 0, 0, relative)
               current_object.number[1] = 1
               if current_object.spawn_sequence < -50 then 
                  current_object.set_scale(1)
               end
            end
            if current_object.spawn_sequence > 74 then 
               global.object[6] = current_object.place_at_me(flag_stand, none, none, 0, 0, 0, troop)
               global.object[6].set_scale(1)
               global.object[6].attach_to(global.object[5], 0, 0, 0, relative)
               current_object.attach_to(global.object[6], 0, 0, 0, relative)
               current_object.number[1] = 1
            end
            if current_object.spawn_sequence > 0 then 
               current_object.attach_to(global.object[5], 0, 0, 0, relative)
               current_object.number[1] = 1
            end
         end
      end
      for each object do
         if global.object[5].spawn_sequence < 0 then 
            global.object[5].set_shape_visibility(everyone)
            if global.object[5].team == current_object.team or global.object[5].team == neutral_team and global.object[5].shape_contains(current_object) and not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) then 
               current_object.attach_to(global.object[5], 0, 0, 0, relative)
            end
         end
      end
   end
end

for each object with label "spawner" do
   if current_object.object[0] == no_object then 
      current_object.number[0] = current_object.spawn_sequence
      if current_object.spawn_sequence == 1 then 
         current_object.object[0] = current_object.place_at_me(bomb, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 2 then 
         current_object.object[0] = current_object.place_at_me(covenant_bomb, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 3 then 
         current_object.object[0] = current_object.place_at_me(flag, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 4 then 
         current_object.object[0] = current_object.place_at_me(skull, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 5 then 
         current_object.object[0] = current_object.place_at_me(unsc_data_core, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 6 then 
         current_object.object[0] = current_object.place_at_me(covenant_power_core, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 7 then 
         current_object.object[0] = current_object.place_at_me(spartan, none, never_garbage_collect, 0, 0, 0, player_skull)
      end
      if current_object.spawn_sequence == 8 then 
         current_object.object[0] = current_object.place_at_me(elite, none, never_garbage_collect, 0, 0, 0, jetpack)
      end
      if current_object.spawn_sequence == 9 then 
         current_object.object[0] = current_object.place_at_me(pelican_scenery, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 10 then 
         current_object.object[0] = current_object.place_at_me(phantom_scenery, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 11 then 
         current_object.object[0] = current_object.place_at_me(warthog_turret, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 12 then 
         current_object.object[0] = current_object.place_at_me(warthog_turret_gauss, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 13 then 
         current_object.object[0] = current_object.place_at_me(warthog_turret_rocket, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 14 then 
         current_object.object[0] = current_object.place_at_me(phantom, none, never_garbage_collect, 0, 0, 0, none)
         current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
      end
      if current_object.spawn_sequence == 15 then 
         current_object.object[0] = current_object.place_at_me(longsword, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 16 then 
         current_object.object[0] = current_object.place_at_me(covenant_power_module_stand, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 17 then 
         current_object.object[0] = current_object.place_at_me(unsc_data_core_holder, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 18 then 
         current_object.object[0] = current_object.place_at_me(longsword, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 19 then
         current_object.object[0] = current_object.place_at_me(falcon_turret_grenade_left, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == 20 then
         current_object.object[0] = current_object.place_at_me(falcon_turret_grenade_right, none, never_garbage_collect, 0, 0, 0, none)
      end
      if current_object.spawn_sequence == -3 then 
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(1, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(2, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(3, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(4, 1)
         end
      end
      if current_object.spawn_sequence == -4 then 
         current_object.set_waypoint_visibility(everyone)
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(5, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(6, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(7, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(8, 1)
         end
      end
      current_object.object[0].copy_rotation_from(current_object, true)
      if current_object.team == team[0] and current_object.spawn_sequence != -5 then 
         current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
      end
   end
   if current_object.spawn_sequence == -5 and current_object.object[0] == no_object then 
      current_object.object[0] = current_object.place_at_me(warthog_turret, none, never_garbage_collect, 0, 0, 0, none)
      if current_object.object[0] == no_object then 
         current_object.object[0] = current_object.place_at_me(monitor, none, never_garbage_collect, 0, 0, 0, none)
      end
      current_object.object[0].set_invincibility(1)
      current_object.object[0].set_scale(50)
      current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
      current_object.object[0].detach()
      current_object.object[0].copy_rotation_from(current_object, true)
      current_object.attach_to(current_object.object[0], 0, 0, 0, relative)
      current_object.object[0].copy_rotation_from(current_object.object[0], false)
   end
   if current_object.spawn_sequence == -6 or current_object.spawn_sequence == -7 and current_object.number[2] == 0 then 
      global.object[7] = no_object
      global.object[7] = current_object
      for each object do
         global.number[7] = current_object.get_distance_to(global.object[7])
         if global.number[7] == 0 and global.object[7] != current_object then 
            if global.object[7].spawn_sequence == -6 then 
               current_object.delete()
            end
            if global.object[7].spawn_sequence == -7 then 
               current_object.attach_to(global.object[7], 0, 0, 0, relative)
            end
            global.object[7].number[2] = 1
         end
      end
   end
   if current_object.spawn_sequence == -8 or current_object.spawn_sequence == -9 then 
      global.object[12] = current_object
      for each object do
         if global.object[12].shape_contains(current_object) and global.object[12].team == current_object.team or global.object[12].team == neutral_team then 
            if global.object[12].spawn_sequence == -8 then 
               current_object.set_invincibility(1)
            end
            if global.object[12].spawn_sequence == -9 then 
               current_object.set_invincibility(0)
            end
         end
      end
   end
end

for each object with label "bro_spawn_loc" do
   current_object.set_invincibility(1)
   current_object.set_pickup_permissions(no_one)
   current_object.set_spawn_location_fireteams(all)
   current_object.set_spawn_location_permissions(allies)
   for each player do
      if current_object.team == current_player.team or current_object.team == neutral_team then 
         current_player.set_primary_respawn_object(current_object)
      end
   end
end

for each player do
   global.number[10] = 0
   if current_player.number[0] == 0 and script_option[13] > 0 then 
      global.object[3] = no_object
      for each object with label "dc_checkpoint" do
         if current_object.number[0] == current_player.number[4] then 
            global.object[3] = current_object
            current_object.set_waypoint_visibility(mod_player, current_player, 1)
            if current_object.shape_contains(current_player.biped) then 
               current_object.set_waypoint_visibility(mod_player, current_player, 0)
               global.number[10] = -1
            end
         end
      end
      if global.number[10] == -1 then 
         current_player.score += script_option[15]
         send_incident(checkpoint_reached_team, current_player, no_player)
         current_player.script_stat[2] += 1
         current_player.number[4] += 1
         for each object with label "dc_checkpoint" do
            if current_object.number[0] == current_player.number[4] then 
               global.number[10] = current_player.number[4]
            end
         end
         if global.number[10] == -1 then
            current_player.number[4] = 0
         end
         if script_option[13] == 2 then
            global.object[3] = get_random_object("dc_checkpoint", global.object[3])
            current_player.number[4] = global.object[3].number[0]
         end
         for each object with label "dc_checkpoint" do
            if current_object.number[0] == current_player.number[4] then
               current_object.set_waypoint_visibility(mod_player, current_player, 1)
            end
         end
      end
   end
end

on local: do
   if global.player[2] == no_player and global.number[2] == 0 or not global.timer[2].is_zero() then 
      if global.object[4] == no_object then
         for each object with label "dc_FXSpawn" do
            global.object[4] = current_object
         end
      end
      for each player do  
         if global.object[2].object[1] == no_object then 
            if global.number[2] == 1 then
               global.object[2].object[1] = current_player.biped.place_at_me(spartan, "hosttarget", none, 15, 0, 0, none)
            end
            if global.number[2] == 0 then
               global.object[2].object[1] = current_player.biped.place_at_me(spartan, "clienttarget", none, 15, 0, 0, none)
            end
            global.object[2].object[1].set_scale(160) 
            global.object[2].object[1].copy_rotation_from(global.object[2].object[1], true)
         end
         global.object[2].object[1].attach_to(current_player.biped, 15, 0, 0, relative)
         global.object[2].object[1].detach()
         global.object[2] = current_player.get_crosshair_target()
         if global.object[2] != no_object then 
            global.player[2] = current_player
            if global.object[4] == no_object then
               global.object[4] = global.player[2].biped
            end
         end
      end
   end
   if global.number[2] > 0 and global.player[2] != no_player or global.timer[2].is_zero() then 
      for each object with label "hosttarget" do
         current_object.delete()
      end
   end
   if global.player[2] != no_player then 
      if global.number[2] == 0 then 
         for each object with label "clienttarget" do
            current_object.delete()
         end
		end
      if script_option[14] > 0 then
         if global.player[2].object[0] == no_object then
            if script_option[14] < 3 then
               global.player[2].object[0] = global.object[4].place_at_me(fx_juicy, none, none, -5, 0, 5, none)
               global.player[2].object[1] = global.object[4].place_at_me(fx_green, none, none, 0, 5, 5, none)
               global.player[2].object[2] = global.object[4].place_at_me(fx_green, none, none, 0, -5, 5, none)
            end
            if script_option[14] > 2 then
               global.player[2].object[0] = global.object[4].place_at_me(fx_juicy, none, none, -5, 0, 5, none)
               global.player[2].object[1] = global.object[4].place_at_me(fx_purple, none, none, 0, 5, 5, none)
               global.player[2].object[2] = global.object[4].place_at_me(fx_gloomy, none, none, 0, -5, 5, none)
            end
         end
      end
	end
   for each player do
      if script_option[14] == 1 or script_option[14] == 3 then
         if current_player.number[0] == 1 then
            current_player.object[0].delete()
            current_player.object[1].delete()
            current_player.object[2].delete()
         end
      end
   end
   for each player do
      global.object[7] = no_object
      for each object with label "dc_checkpoint" do
         if current_object.number[0] == current_player.number[4] then
            global.object[7] = current_object
         end
      end
      if current_player.number[0] == 0 then
         current_player.number[5] = 0
         current_player.number[5] = current_player.biped.get_distance_to(global.object[7])
         current_player.number[5] *= 7
         current_player.number[5] /= 23
      end
   end

   for each object with label "object_by_index" do
      if current_object.timer[3].is_zero() then 
         current_object.object[3].detach()
         current_object.object[3].copy_rotation_from(current_object, true)
         current_object.timer[3].reset()
      end
      if current_object.object[3] == no_object then 
         current_object.timer[3].set_rate(-100%)
         global.number[5] = current_object.spawn_sequence
         global.number[5] += 100
         global.object[14] = no_object
         global.number[6] = 0
         for each object do
            if not current_object.is_of_type(monitor) and not current_object.is_of_type(flag_stand) and not current_object.is_of_type(kill_ball) and not current_object.is_of_type(elite) and not current_object.is_of_type(spartan) and not current_object.is_of_type(landmine) and not current_object.is_of_type(hill_marker) and not current_object.is_of_type(capture_plate) then 
               if global.number[6] == global.number[5] then 
                  global.object[14] = current_object
               end
               global.number[6] += 1
            end
         end
         current_object.object[3] = global.object[14]
         current_object.object[3].copy_rotation_from(current_object, true)
         current_object.object[3].attach_to(current_object, 0, 0, 0, relative)
      end
   end
   for each object with label "scale" do
      if current_object.number[2] == 0 then 
         if current_object.team == team[2] or current_object.team == team[3] and current_object.object[2] != no_object then 
            trigger_0()
            current_object.copy_rotation_from(current_object, true)
            current_object.attach_to(current_object.object[2], 0, 0, 0, relative)
         end
         if current_object.team != team[2] and current_object.team != team[3] then 
            trigger_0()
         end
      end
      if current_object.is_of_type(hill_marker) then 
         current_object.set_shape_visibility(everyone)
         if current_object.team == team[7] or current_object.team == team[5] then 
            current_object.number[1] = current_object.spawn_sequence
            if current_object.spawn_sequence == 0 then 
               current_object.number[1] = 100
            end
            if current_object.spawn_sequence < 0 then 
               current_object.number[1] *= -1
               current_object.number[1] += 100
            end
         end
         global.object[15] = current_object
         for each object do
            if global.object[15].team == current_object.team or global.object[15].team == neutral_team or global.object[15].team == team[5] or global.object[15].team == team[6] or global.object[15].team == team[7] and global.object[15].shape_contains(current_object) and global.object[15] != current_object and current_object.number[7] != 9999 then 
               current_object.set_scale(global.object[15].number[1])
               current_object.copy_rotation_from(current_object, false)
               if global.object[15].team == team[6] or global.object[15].team == team[7] then 
                  current_object.number[7] = 9999
               end
            end
         end
      end
   end
   for each object with label "spawner" do
      if current_object.spawn_sequence == -3 then 
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(1, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(2, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(3, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(4, 1)
         end
      end
      if current_object.spawn_sequence == -4 then 
         current_object.set_waypoint_visibility(everyone)
         if current_object.team == team[1] then 
            set_scenario_interpolator_state(5, 1)
         end
         if current_object.team == team[3] then 
            set_scenario_interpolator_state(6, 1)
         end
         if current_object.team == team[5] then 
            set_scenario_interpolator_state(7, 1)
         end
         if current_object.team == team[7] then 
            set_scenario_interpolator_state(8, 1)
         end
      end
   end
end
